-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2019-11-20 19:37:30.441

-- tables
-- Table: Admin
CREATE TABLE Admin (
    id_admin int  NOT NULL,
    first_name varchar(1024)  NOT NULL,
    last_name varchar(1024)  NOT NULL,
    CONSTRAINT Admin_pk PRIMARY KEY  (id_admin)
);

-- Table: Delivery_Driver
CREATE TABLE Delivery_Driver (
    id_delivery_driver int  NOT NULL,
    first_name varchar(1024)  NOT NULL,
    last_name varchar(1024)  NOT NULL,
    CONSTRAINT Delivery_Driver_pk PRIMARY KEY  (id_delivery_driver)
);

-- Table: Discount
CREATE TABLE Discount (
    id_discount int  NOT NULL,
    name varchar(1024)  NOT NULL,
    CONSTRAINT Discount_pk PRIMARY KEY  (id_discount)
);

-- Table: Order
CREATE TABLE "Order" (
    id_order int  NOT NULL,
    customer_address varchar(1024)  NOT NULL,
    customer_contact varchar(1024)  NOT NULL,
    accepted_time datetime  NULL,
    delivery_time datetime  NULL,
    Restaurant_id_restaurant int  NOT NULL,
    Delivery_Driver_id_delivery_driver int  NOT NULL,
    Admin_id_admin int  NOT NULL,
    Discount_id_discount int  NOT NULL,
    CONSTRAINT Order_pk PRIMARY KEY  (id_order)
);

-- Table: Pizza
CREATE TABLE Pizza (
    id_pizza int  NOT NULL,
    name varchar(1024)  NOT NULL,
    price varchar(1024)  NOT NULL,
    is_standard int  NOT NULL,
    Type_Of_Bread_name varchar(1024)  NOT NULL,
    CONSTRAINT Pizza_pk PRIMARY KEY  (id_pizza)
);

-- Table: Pizza_Order
CREATE TABLE Pizza_Order (
    Pizza_id_pizza int  NOT NULL,
    Order_id_order int  NOT NULL,
    CONSTRAINT Pizza_Order_pk PRIMARY KEY  (Pizza_id_pizza,Order_id_order)
);

-- Table: Pizza_Topping
CREATE TABLE Pizza_Topping (
    Pizza_id_pizza int  NOT NULL,
    Topping_id_topping int  NOT NULL,
    CONSTRAINT Pizza_Topping_pk PRIMARY KEY  (Pizza_id_pizza,Topping_id_topping)
);

-- Table: Restaurant
CREATE TABLE Restaurant (
    id_restaurant int  NOT NULL,
    name varchar(1024)  NOT NULL,
    address varchar(1024)  NOT NULL,
    contact_number varchar(1024)  NOT NULL,
    CONSTRAINT Restaurant_pk PRIMARY KEY  (id_restaurant)
);

-- Table: Topping
CREATE TABLE Topping (
    id_topping int  NOT NULL,
    name varchar(1024)  NOT NULL,
    price varchar(1024)  NOT NULL,
    CONSTRAINT Topping_pk PRIMARY KEY  (id_topping)
);

-- Table: Type_Of_Bread
CREATE TABLE Type_Of_Bread (
    name varchar(1024)  NOT NULL,
    CONSTRAINT Type_Of_Bread_pk PRIMARY KEY  (name)
);

-- foreign keys
-- Reference: Order_Admin (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_Admin
    FOREIGN KEY (Admin_id_admin)
    REFERENCES Admin (id_admin);

-- Reference: Order_Delivery_Driver (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_Delivery_Driver
    FOREIGN KEY (Delivery_Driver_id_delivery_driver)
    REFERENCES Delivery_Driver (id_delivery_driver);

-- Reference: Order_Discount (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_Discount
    FOREIGN KEY (Discount_id_discount)
    REFERENCES Discount (id_discount);

-- Reference: Order_Restaurant (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_Restaurant
    FOREIGN KEY (Restaurant_id_restaurant)
    REFERENCES Restaurant (id_restaurant);

-- Reference: Pizza_Order_Order (table: Pizza_Order)
ALTER TABLE Pizza_Order ADD CONSTRAINT Pizza_Order_Order
    FOREIGN KEY (Order_id_order)
    REFERENCES "Order" (id_order);

-- Reference: Pizza_Order_Pizza (table: Pizza_Order)
ALTER TABLE Pizza_Order ADD CONSTRAINT Pizza_Order_Pizza
    FOREIGN KEY (Pizza_id_pizza)
    REFERENCES Pizza (id_pizza);

-- Reference: Pizza_Topping_Pizza (table: Pizza_Topping)
ALTER TABLE Pizza_Topping ADD CONSTRAINT Pizza_Topping_Pizza
    FOREIGN KEY (Pizza_id_pizza)
    REFERENCES Pizza (id_pizza);

-- Reference: Pizza_Topping_Topping (table: Pizza_Topping)
ALTER TABLE Pizza_Topping ADD CONSTRAINT Pizza_Topping_Topping
    FOREIGN KEY (Topping_id_topping)
    REFERENCES Topping (id_topping);

-- Reference: Pizza_Type_Of_Bread (table: Pizza)
ALTER TABLE Pizza ADD CONSTRAINT Pizza_Type_Of_Bread
    FOREIGN KEY (Type_Of_Bread_name)
    REFERENCES Type_Of_Bread (name);

-- End of file.

