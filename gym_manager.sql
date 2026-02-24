-- ============================================
-- DROP EXISTING TABLES (in reverse order)
-- ============================================
DROP TABLE IF EXISTS attendance;
DROP TABLE IF EXISTS bookings;
DROP TABLE IF EXISTS class_instances;
DROP TABLE IF EXISTS class_schedules;
DROP TABLE IF EXISTS rooms;
DROP TABLE IF EXISTS instructors;
DROP TABLE IF EXISTS class_types;
DROP TABLE IF EXISTS subscriptions;
DROP TABLE IF EXISTS membership_plans;
DROP TABLE IF EXISTS members;

-- ============================================
-- CREATE TABLES (in correct dependency order)
-- ============================================

-- 1. MEMBERS (no dependencies)
CREATE TABLE members (
    member_id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    phone VARCHAR(20),
    date_of_birth DATE,
    join_date DATE NOT NULL DEFAULT (CURRENT_DATE),
    status ENUM('active', 'inactive', 'suspended') NOT NULL DEFAULT 'active',
    emergency_contact_name VARCHAR(100),
    emergency_contact_phone VARCHAR(20),
    medical_notes TEXT,
    face_id VARCHAR(36) NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_face_id (face_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 2. MEMBERSHIP_PLANS (no dependencies)
CREATE TABLE membership_plans (
    plan_id INT AUTO_INCREMENT PRIMARY KEY,
    plan_name VARCHAR(100) NOT NULL,
    duration_months INT NOT NULL CHECK (duration_months >= 0),
    price DECIMAL(10, 2) NOT NULL CHECK (price >= 0),
    max_classes_per_month INT CHECK (max_classes_per_month > 0),
    description TEXT,
    is_active TINYINT(1) DEFAULT 1,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 3. SUBSCRIPTIONS (depends on members and membership_plans)
CREATE TABLE subscriptions (
    subscription_id INT AUTO_INCREMENT PRIMARY KEY,
    member_id INT NOT NULL,
    plan_id INT NOT NULL,
    start_date DATE NOT NULL DEFAULT (CURRENT_DATE),
    end_date DATE NOT NULL,
    status ENUM('active', 'expired', 'paused', 'cancelled') NOT NULL DEFAULT 'active',
    payment_status ENUM('paid', 'pending', 'failed') NOT NULL DEFAULT 'pending',
    auto_renew TINYINT(1) DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT valid_dates CHECK (end_date > start_date),
    CONSTRAINT fk_sub_member FOREIGN KEY (member_id) 
        REFERENCES members(member_id) ON DELETE CASCADE,
    CONSTRAINT fk_sub_plan FOREIGN KEY (plan_id) 
        REFERENCES membership_plans(plan_id),
    INDEX idx_member (member_id),
    INDEX idx_plan (plan_id),
    INDEX idx_active (member_id, status, end_date)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 4. CLASS_TYPES (no dependencies)
CREATE TABLE class_types (
    class_type_id INT AUTO_INCREMENT PRIMARY KEY,
    class_name VARCHAR(100) NOT NULL,
    description TEXT,
    duration_minutes INT NOT NULL CHECK (duration_minutes > 0),
    default_capacity INT NOT NULL CHECK (default_capacity > 0),
    difficulty_level ENUM('beginner', 'intermediate', 'advanced'),
    equipment_required TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 5. INSTRUCTORS (no dependencies)
CREATE TABLE instructors (
    instructor_id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    phone VARCHAR(20),
    certifications TEXT,
    specializations TEXT,
    hire_date DATE NOT NULL DEFAULT (CURRENT_DATE),
    status ENUM('active', 'inactive') NOT NULL DEFAULT 'active',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 6. ROOMS (no dependencies)
CREATE TABLE rooms (
    room_id INT AUTO_INCREMENT PRIMARY KEY,
    room_name VARCHAR(100) NOT NULL,
    capacity INT NOT NULL CHECK (capacity > 0),
    equipment_available TEXT,
    status ENUM('available', 'maintenance', 'closed') NOT NULL DEFAULT 'available',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 7. CLASS_SCHEDULES (depends on class_types, instructors, rooms)
CREATE TABLE class_schedules (
    schedule_id INT AUTO_INCREMENT PRIMARY KEY,
    class_type_id INT NOT NULL,
    instructor_id INT NOT NULL,
    room_id INT NOT NULL,
    day_of_week TINYINT NOT NULL CHECK (day_of_week BETWEEN 1 AND 7),
    start_time TIME NOT NULL,
    is_active TINYINT(1) DEFAULT 1,
    effective_from DATE NOT NULL DEFAULT (CURRENT_DATE),
    effective_until DATE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_schedule_classtype FOREIGN KEY (class_type_id) 
        REFERENCES class_types(class_type_id),
    CONSTRAINT fk_schedule_instructor FOREIGN KEY (instructor_id) 
        REFERENCES instructors(instructor_id),
    CONSTRAINT fk_schedule_room FOREIGN KEY (room_id) 
        REFERENCES rooms(room_id),
    INDEX idx_classtype (class_type_id),
    INDEX idx_instructor (instructor_id),
    INDEX idx_room (room_id),
    INDEX idx_active_schedule (is_active, day_of_week)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 8. CLASS_INSTANCES (depends on class_schedules, instructors, rooms)
CREATE TABLE class_instances (
    instance_id INT AUTO_INCREMENT PRIMARY KEY,
    schedule_id INT NOT NULL,
    class_date DATE NOT NULL,
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    instructor_id INT NOT NULL,
    room_id INT NOT NULL,
    capacity INT NOT NULL CHECK (capacity > 0),
    current_bookings INT NOT NULL DEFAULT 0 CHECK (current_bookings >= 0),
    status ENUM('scheduled', 'in_progress', 'completed', 'cancelled') NOT NULL DEFAULT 'scheduled',
    cancellation_reason TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT valid_capacity CHECK (current_bookings <= capacity),
    CONSTRAINT unique_class_instance UNIQUE (schedule_id, class_date),
    CONSTRAINT fk_instance_schedule FOREIGN KEY (schedule_id) 
        REFERENCES class_schedules(schedule_id),
    CONSTRAINT fk_instance_instructor FOREIGN KEY (instructor_id) 
        REFERENCES instructors(instructor_id),
    CONSTRAINT fk_instance_room FOREIGN KEY (room_id) 
        REFERENCES rooms(room_id),
    INDEX idx_schedule (schedule_id),
    INDEX idx_instructor (instructor_id),
    INDEX idx_room (room_id),
    INDEX idx_date_status (class_date, status),
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 9. BOOKINGS (depends on members and class_instances)
CREATE TABLE bookings (
    booking_id INT AUTO_INCREMENT PRIMARY KEY,
    member_id INT NOT NULL,
    instance_id INT NOT NULL,
    booking_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    status ENUM('confirmed', 'cancelled', 'no_show') NOT NULL DEFAULT 'confirmed';
    cancelled_at TIMESTAMP NULL,
    cancellation_reason TEXT,
    CONSTRAINT fk_booking_member FOREIGN KEY (member_id) 
        REFERENCES members(member_id) ON DELETE CASCADE,
    CONSTRAINT fk_booking_instance FOREIGN KEY (instance_id) 
        REFERENCES class_instances(instance_id) ON DELETE CASCADE,
    INDEX idx_member (member_id),
    INDEX idx_instance (instance_id),
    INDEX idx_member_instance (member_id, instance_id),
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 10. ATTENDANCE (depends on bookings)
CREATE TABLE attendance (
    attendance_id INT AUTO_INCREMENT PRIMARY KEY,
    booking_id INT NOT NULL,
    check_in_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    attended TINYINT(1) DEFAULT 1,
    notes TEXT,
    CONSTRAINT unique_attendance UNIQUE (booking_id),
    CONSTRAINT fk_attendance_booking FOREIGN KEY (booking_id) 
        REFERENCES bookings(booking_id) ON DELETE CASCADE,
    INDEX idx_booking (booking_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;