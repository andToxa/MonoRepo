-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: May 21, 2024 at 10:32 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `djangoecom`
--

-- --------------------------------------------------------

--
-- Table structure for table `auth_group`
--

CREATE TABLE `auth_group` (
  `id` int(11) NOT NULL,
  `name` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `auth_group_permissions`
--

CREATE TABLE `auth_group_permissions` (
  `id` bigint(20) NOT NULL,
  `group_id` int(11) NOT NULL,
  `permission_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `auth_permission`
--

CREATE TABLE `auth_permission` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `content_type_id` int(11) NOT NULL,
  `codename` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `auth_permission`
--

INSERT INTO `auth_permission` (`id`, `name`, `content_type_id`, `codename`) VALUES
(1, 'Can add log entry', 1, 'add_logentry'),
(2, 'Can change log entry', 1, 'change_logentry'),
(3, 'Can delete log entry', 1, 'delete_logentry'),
(4, 'Can view log entry', 1, 'view_logentry'),
(5, 'Can add permission', 2, 'add_permission'),
(6, 'Can change permission', 2, 'change_permission'),
(7, 'Can delete permission', 2, 'delete_permission'),
(8, 'Can view permission', 2, 'view_permission'),
(9, 'Can add group', 3, 'add_group'),
(10, 'Can change group', 3, 'change_group'),
(11, 'Can delete group', 3, 'delete_group'),
(12, 'Can view group', 3, 'view_group'),
(13, 'Can add user', 4, 'add_user'),
(14, 'Can change user', 4, 'change_user'),
(15, 'Can delete user', 4, 'delete_user'),
(16, 'Can view user', 4, 'view_user'),
(17, 'Can add content type', 5, 'add_contenttype'),
(18, 'Can change content type', 5, 'change_contenttype'),
(19, 'Can delete content type', 5, 'delete_contenttype'),
(20, 'Can view content type', 5, 'view_contenttype'),
(21, 'Can add session', 6, 'add_session'),
(22, 'Can change session', 6, 'change_session'),
(23, 'Can delete session', 6, 'delete_session'),
(24, 'Can view session', 6, 'view_session'),
(25, 'Can add category', 7, 'add_category'),
(26, 'Can change category', 7, 'change_category'),
(27, 'Can delete category', 7, 'delete_category'),
(28, 'Can view category', 7, 'view_category'),
(29, 'Can add product', 8, 'add_product'),
(30, 'Can change product', 8, 'change_product'),
(31, 'Can delete product', 8, 'delete_product'),
(32, 'Can view product', 8, 'view_product'),
(33, 'Can add cart', 9, 'add_cart'),
(34, 'Can change cart', 9, 'change_cart'),
(35, 'Can delete cart', 9, 'delete_cart'),
(36, 'Can view cart', 9, 'view_cart'),
(37, 'Can add order', 10, 'add_order'),
(38, 'Can change order', 10, 'change_order'),
(39, 'Can delete order', 10, 'delete_order'),
(40, 'Can view order', 10, 'view_order'),
(41, 'Can add order item', 11, 'add_orderitem'),
(42, 'Can change order item', 11, 'change_orderitem'),
(43, 'Can delete order item', 11, 'delete_orderitem'),
(44, 'Can view order item', 11, 'view_orderitem'),
(45, 'Can add profile', 12, 'add_profile'),
(46, 'Can change profile', 12, 'change_profile'),
(47, 'Can delete profile', 12, 'delete_profile'),
(48, 'Can view profile', 12, 'view_profile');

-- --------------------------------------------------------

--
-- Table structure for table `auth_user`
--

CREATE TABLE `auth_user` (
  `id` int(11) NOT NULL,
  `password` varchar(128) NOT NULL,
  `last_login` datetime(6) DEFAULT NULL,
  `is_superuser` tinyint(1) NOT NULL,
  `username` varchar(150) NOT NULL,
  `first_name` varchar(150) NOT NULL,
  `last_name` varchar(150) NOT NULL,
  `email` varchar(254) NOT NULL,
  `is_staff` tinyint(1) NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `date_joined` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `auth_user`
--

INSERT INTO `auth_user` (`id`, `password`, `last_login`, `is_superuser`, `username`, `first_name`, `last_name`, `email`, `is_staff`, `is_active`, `date_joined`) VALUES
(1, 'pbkdf2_sha256$600000$jvXRxQkmhuDq3ou6uZmBRa$q6/QElzFhYzz09gcN0pI5/AJoVu4Br4Caph5gmjaWx0=', '2024-05-21 08:16:54.295440', 0, 'omo', 'omo1', 'Кира', 'sharmaa1@gmail.com', 0, 1, '2024-05-18 14:08:26.924241'),
(2, 'pbkdf2_sha256$600000$UQ0k6avU5Tifk9kAZ3KXtb$PxOuVA4747usi5WnKE0rzuoCWy/rvnyhnDC52JsGK+Q=', '2024-05-18 14:09:58.480145', 1, 'omoadmin', 'omo', 'omo', 'sharma@mail.com', 1, 1, '2024-05-18 14:09:47.210203'),
(3, 'pbkdf2_sha256$600000$uzRnuzk6GiFrtA3dxf2QI6$kTIvnVdgrm9kPkw1mnaW3+pMskARGRPYWQP7VlO1ea0=', '2024-05-21 08:17:59.373450', 1, 'omoadmin1', '', '', 'omo@mail.com', 1, 1, '2024-05-19 14:09:32.457008');

-- --------------------------------------------------------

--
-- Table structure for table `auth_user_groups`
--

CREATE TABLE `auth_user_groups` (
  `id` bigint(20) NOT NULL,
  `user_id` int(11) NOT NULL,
  `group_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `auth_user_user_permissions`
--

CREATE TABLE `auth_user_user_permissions` (
  `id` bigint(20) NOT NULL,
  `user_id` int(11) NOT NULL,
  `permission_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `django_admin_log`
--

CREATE TABLE `django_admin_log` (
  `id` int(11) NOT NULL,
  `action_time` datetime(6) NOT NULL,
  `object_id` longtext DEFAULT NULL,
  `object_repr` varchar(200) NOT NULL,
  `action_flag` smallint(5) UNSIGNED NOT NULL CHECK (`action_flag` >= 0),
  `change_message` longtext NOT NULL,
  `content_type_id` int(11) DEFAULT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `django_admin_log`
--

INSERT INTO `django_admin_log` (`id`, `action_time`, `object_id`, `object_repr`, `action_flag`, `change_message`, `content_type_id`, `user_id`) VALUES
(1, '2024-05-18 14:11:54.436781', '1', 'Диваны', 1, '[{\"added\": {}}]', 7, 2),
(2, '2024-05-18 14:12:29.129182', '2', 'Кресла', 1, '[{\"added\": {}}]', 7, 2),
(3, '2024-05-18 14:13:05.169428', '3', 'Кушетки', 1, '[{\"added\": {}}]', 7, 2),
(4, '2024-05-18 14:15:38.141228', '1', 'Диван-кровать «Фьорд»', 1, '[{\"added\": {}}]', 8, 2),
(5, '2024-05-18 14:18:21.746750', '2', 'Диван-кровать «Амстердам»', 1, '[{\"added\": {}}]', 8, 2),
(6, '2024-05-18 14:20:26.525016', '3', 'Угловой диван-кровать «Кост-А»', 1, '[{\"added\": {}}]', 8, 2),
(7, '2024-05-18 14:21:43.380787', '4', 'Диван-кровать «Арбат»', 1, '[{\"added\": {}}]', 8, 2),
(8, '2024-05-18 14:23:52.570199', '5', 'Кресло «Амбер»', 1, '[{\"added\": {}}]', 8, 2),
(9, '2024-05-18 14:26:30.927186', '6', 'Кресло «Астер»', 1, '[{\"added\": {}}]', 8, 2),
(10, '2024-05-18 14:28:18.840716', '7', 'Кресло «Вилсон»', 1, '[{\"added\": {}}]', 8, 2),
(11, '2024-05-18 14:29:59.970348', '8', 'Кресло «Волана»', 1, '[{\"added\": {}}]', 8, 2),
(12, '2024-05-18 14:31:23.975917', '9', 'Кушетка «Прайм»', 1, '[{\"added\": {}}]', 8, 2),
(13, '2024-05-18 14:32:34.072959', '10', 'Кушетка «Атико»', 1, '[{\"added\": {}}]', 8, 2),
(14, '2024-05-18 14:33:50.249752', '11', 'Кушетка «Камерон»', 1, '[{\"added\": {}}]', 8, 2),
(15, '2024-05-18 14:35:16.283197', '12', 'Кушетка «Лорд»', 1, '[{\"added\": {}}]', 8, 2);

-- --------------------------------------------------------

--
-- Table structure for table `django_content_type`
--

CREATE TABLE `django_content_type` (
  `id` int(11) NOT NULL,
  `app_label` varchar(100) NOT NULL,
  `model` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `django_content_type`
--

INSERT INTO `django_content_type` (`id`, `app_label`, `model`) VALUES
(1, 'admin', 'logentry'),
(3, 'auth', 'group'),
(2, 'auth', 'permission'),
(4, 'auth', 'user'),
(5, 'contenttypes', 'contenttype'),
(6, 'sessions', 'session'),
(9, 'store', 'cart'),
(7, 'store', 'category'),
(10, 'store', 'order'),
(11, 'store', 'orderitem'),
(8, 'store', 'product'),
(12, 'store', 'profile');

-- --------------------------------------------------------

--
-- Table structure for table `django_migrations`
--

CREATE TABLE `django_migrations` (
  `id` bigint(20) NOT NULL,
  `app` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `applied` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `django_migrations`
--

INSERT INTO `django_migrations` (`id`, `app`, `name`, `applied`) VALUES
(1, 'contenttypes', '0001_initial', '2024-05-18 14:06:55.590201'),
(2, 'auth', '0001_initial', '2024-05-18 14:06:55.986694'),
(3, 'admin', '0001_initial', '2024-05-18 14:06:56.090541'),
(4, 'admin', '0002_logentry_remove_auto_add', '2024-05-18 14:06:56.103533'),
(5, 'admin', '0003_logentry_add_action_flag_choices', '2024-05-18 14:06:56.114506'),
(6, 'contenttypes', '0002_remove_content_type_name', '2024-05-18 14:06:56.172874'),
(7, 'auth', '0002_alter_permission_name_max_length', '2024-05-18 14:06:56.220482'),
(8, 'auth', '0003_alter_user_email_max_length', '2024-05-18 14:06:56.242466'),
(9, 'auth', '0004_alter_user_username_opts', '2024-05-18 14:06:56.254459'),
(10, 'auth', '0005_alter_user_last_login_null', '2024-05-18 14:06:56.290557'),
(11, 'auth', '0006_require_contenttypes_0002', '2024-05-18 14:06:56.294557'),
(12, 'auth', '0007_alter_validators_add_error_messages', '2024-05-18 14:06:56.304349'),
(13, 'auth', '0008_alter_user_username_max_length', '2024-05-18 14:06:56.327554'),
(14, 'auth', '0009_alter_user_last_name_max_length', '2024-05-18 14:06:56.347538'),
(15, 'auth', '0010_alter_group_name_max_length', '2024-05-18 14:06:56.365361'),
(16, 'auth', '0011_update_proxy_permissions', '2024-05-18 14:06:56.375355'),
(17, 'auth', '0012_alter_user_first_name_max_length', '2024-05-18 14:06:56.392393'),
(18, 'sessions', '0001_initial', '2024-05-18 14:06:56.415411'),
(19, 'store', '0001_initial', '2024-05-18 14:06:56.569138'),
(20, 'store', '0002_order_orderitem', '2024-05-18 14:06:56.745793'),
(21, 'store', '0003_profile', '2024-05-18 14:06:56.814956'),
(22, 'store', '0004_profile_flatnumb', '2024-05-18 14:06:56.840918'),
(23, 'store', '0005_profile_email', '2024-05-18 14:06:56.866671'),
(24, 'store', '0006_alter_profile_flatnumb', '2024-05-19 15:01:50.416050'),
(25, 'store', '0007_profile_housenum', '2024-05-19 15:04:56.376505'),
(26, 'store', '0008_order_housenum', '2024-05-19 15:07:31.163436'),
(27, 'store', '0009_alter_order_flatnumb', '2024-05-19 15:13:47.218169');

-- --------------------------------------------------------

--
-- Table structure for table `django_session`
--

CREATE TABLE `django_session` (
  `session_key` varchar(40) NOT NULL,
  `session_data` longtext NOT NULL,
  `expire_date` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `django_session`
--

INSERT INTO `django_session` (`session_key`, `session_data`, `expire_date`) VALUES
('5axo9ww9fys3oy2iwvez2hyjcp74rxrv', '.eJxVjDsOwjAQBe_iGln4k2yWkj5nsNa7Ng4gR4qTCnF3iJQC2jcz76UCbWsJW0tLmERdlFOn3y0SP1Ldgdyp3mbNc12XKepd0QdtepwlPa-H-3dQqJVvTTmyydAL8NkDgaDrBJHEDJ4yJmbPgJbYGeslpj4acAAdDZbQSFbvDwoUOKA:1s9Kh5:AzTvLMEtJCEyEu5syAzL9_oa9n7apOfvHHrFjAcio0o', '2024-06-04 08:17:59.381449'),
('e2om6a7kzfooa5gaical6givyu53tt13', '.eJxVjDEOAiEQRe9CbQgIwmBp7xkIwwyyaiBZdivj3XWTLbT9773_EjGtS43r4DlOJM5Ci8Pvhik_uG2A7qndusy9LfOEclPkToe8duLnZXf_Dmoa9VvbYgsaPPqsPWABU5gJfCBnwCgHhQOo4JiygpP3oAgCmKQSFkJntXh_AO3hN_4:1s8brO:cPFIVaoUR5kimK8HCsVcX0CCPh5YTHxkW1O92NaDBMw', '2024-06-02 08:25:38.408123'),
('i8panp6nwhvkjv5tjthneg13g2ep48jp', '.eJxVjDEOAiEQRe9CbQgIwmBp7xkIwwyyaiBZdivj3XWTLbT9773_EjGtS43r4DlOJM5Ci8Pvhik_uG2A7qndusy9LfOEclPkToe8duLnZXf_Dmoa9VvbYgsaPPqsPWABU5gJfCBnwCgHhQOo4JiygpP3oAgCmKQSFkJntXh_AO3hN_4:1s8bZm:i2_lzCH1kFsupfKsbYu3p30O6DqtioP-51WsrW3v-dQ', '2024-06-02 08:07:26.280468'),
('m8mb2ug19u6nrggsqfnhpmrilb5iq5xo', '.eJxVjDsOwjAQBe_iGln4k2yWkj5nsNa7Ng4gR4qTCnF3iJQC2jcz76UCbWsJW0tLmERdlFOn3y0SP1Ldgdyp3mbNc12XKepd0QdtepwlPa-H-3dQqJVvTTmyydAL8NkDgaDrBJHEDJ4yJmbPgJbYGeslpj4acAAdDZbQSFbvDwoUOKA:1s95FU:sCxflt7TrsV3l4CUtRyL6vHKhhVgcGYAt5gUI3MP4Eo', '2024-06-03 15:48:28.040184'),
('vepncjb3zfp5aqhoigpy3nn606oppf9p', '.eJxVjDEOAiEQRe9CbQgIwmBp7xkIwwyyaiBZdivj3XWTLbT9773_EjGtS43r4DlOJM5Ci8Pvhik_uG2A7qndusy9LfOEclPkToe8duLnZXf_Dmoa9VvbYgsaPPqsPWABU5gJfCBnwCgHhQOo4JiygpP3oAgCmKQSFkJntXh_AO3hN_4:1s8LAT:sWA0NCRg0VIhM1jtI-MSnS-Xw5XmllxSy-pwa4c8JDw', '2024-06-01 14:36:13.337024'),
('xxjttnf2grj9x8b3ws74jz5el0ypyo5x', '.eJxVjDEOAiEQRe9CbQgIwmBp7xkIwwyyaiBZdivj3XWTLbT9773_EjGtS43r4DlOJM5Ci8Pvhik_uG2A7qndusy9LfOEclPkToe8duLnZXf_Dmoa9VvbYgsaPPqsPWABU5gJfCBnwCgHhQOo4JiygpP3oAgCmKQSFkJntXh_AO3hN_4:1s8c5e:VVxpWAgK0o0xQ33F_Egg8UwVvbOvRPtprxbOau9G5MM', '2024-06-02 08:40:22.926254');

-- --------------------------------------------------------

--
-- Table structure for table `store_cart`
--

CREATE TABLE `store_cart` (
  `id` bigint(20) NOT NULL,
  `product_qty` int(11) NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `product_id` bigint(20) NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `store_cart`
--

INSERT INTO `store_cart` (`id`, `product_qty`, `created_at`, `product_id`, `user_id`) VALUES
(1, 3, '2024-05-18 14:35:26.731685', 6, 2);

-- --------------------------------------------------------

--
-- Table structure for table `store_category`
--

CREATE TABLE `store_category` (
  `id` bigint(20) NOT NULL,
  `slug` varchar(150) NOT NULL,
  `name` varchar(150) NOT NULL,
  `image` varchar(100) DEFAULT NULL,
  `description` longtext NOT NULL,
  `status` tinyint(1) NOT NULL,
  `trending` tinyint(1) NOT NULL,
  `meta_title` varchar(150) NOT NULL,
  `meta_keywords` varchar(150) NOT NULL,
  `meta_description` longtext NOT NULL,
  `created_at` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `store_category`
--

INSERT INTO `store_category` (`id`, `slug`, `name`, `image`, `description`, `status`, `trending`, `meta_title`, `meta_keywords`, `meta_description`, `created_at`) VALUES
(1, 'Couch', 'Диваны', 'upload/2024-05-18211154category_1_divany.jpg', 'Диваны', 0, 0, 'Couch', 'couch', 'have', '2024-05-18 14:11:54.433781'),
(2, 'Armchair', 'Кресла', 'upload/2024-05-18211229category_2_kresla.jpg', 'Кресла', 0, 0, 'Armchair', 'armchair', 'have', '2024-05-18 14:12:29.128183'),
(3, 'Kyshetki', 'Кушетки', 'upload/2024-05-18211305category_3_kushetki.jpg', 'Кушетки', 0, 0, 'Kyshetki', 'Kushetki', 'have', '2024-05-18 14:13:05.168461');

-- --------------------------------------------------------

--
-- Table structure for table `store_order`
--

CREATE TABLE `store_order` (
  `id` bigint(20) NOT NULL,
  `fname` varchar(150) NOT NULL,
  `lname` varchar(150) NOT NULL,
  `email` varchar(150) NOT NULL,
  `phone` varchar(150) NOT NULL,
  `area` varchar(150) NOT NULL,
  `city` varchar(150) NOT NULL,
  `adress` longtext NOT NULL,
  `flatnumb` varchar(150) DEFAULT NULL,
  `total_price` double NOT NULL,
  `payment_mode` varchar(150) NOT NULL,
  `payment_id` varchar(250) DEFAULT NULL,
  `status` varchar(150) NOT NULL,
  `message` longtext DEFAULT NULL,
  `tracking_no` varchar(150) DEFAULT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  `user_id` int(11) NOT NULL,
  `housenum` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `store_order`
--

INSERT INTO `store_order` (`id`, `fname`, `lname`, `email`, `phone`, `area`, `city`, `adress`, `flatnumb`, `total_price`, `payment_mode`, `payment_id`, `status`, `message`, `tracking_no`, `created_at`, `updated_at`, `user_id`, `housenum`) VALUES
(1, 'omo', 'omo', 'sharma@mail.com', 'a', 'a', 'a', 'a', 'a', 82254, 'COD', NULL, 'Pending', NULL, 'sharma252651799725', '2024-05-18 14:35:42.513025', '2024-05-18 14:35:42.514029', 2, NULL),
(2, 'omo', 'omo', 'sharma@gmail.com', 'a', 'b', 'b', 'b', 'b', 109672, 'COD', NULL, 'Pending', NULL, 'sharma746746803025', '2024-05-18 14:36:30.898598', '2024-05-18 14:36:30.898598', 1, NULL),
(3, 'omo', 'omo', 'sharma@gmail.com', 'a', 'b', 'b', 'b', 'b', 109672, 'COD', NULL, 'Pending', NULL, 'sharma604830643552', '2024-05-18 14:40:18.758143', '2024-05-18 14:40:18.758143', 1, NULL),
(4, 'omo', 'omo', 'sharma@gmail.com', 'a', 'b', 'b', 'b', 'b', 109672, 'COD', NULL, 'Pending', NULL, 'sharma501074373767', '2024-05-18 14:41:03.344831', '2024-05-18 14:41:03.344831', 1, NULL),
(5, 'omo', 'omo', '', 'a', 'b', 'b', 'b', 'b', 109672, 'COD', NULL, 'Pending', NULL, 'sharma290671539452', '2024-05-18 14:42:59.038230', '2024-05-18 14:42:59.038230', 1, NULL),
(6, 'omo', 'omo', 'sharma1@gmail.com', 'a', 'b', 'b', 'b', 'b', 109672, 'COD', NULL, 'Pending', NULL, 'sharma300900902920', '2024-05-19 06:24:26.126747', '2024-05-19 06:24:26.126747', 1, NULL),
(7, 'omo1', 'omo', '', 'a', 'b', 'b', 'b', 'b', 54836, 'COD', NULL, 'Pending', NULL, 'sharma128188891535', '2024-05-19 06:31:44.477785', '2024-05-19 06:31:44.478784', 1, NULL),
(8, 'omo', 'omo', '', 'a', 'b', 'b', 'b', 'b', 54836, 'COD', NULL, 'Pending', NULL, 'sharma499208668083', '2024-05-19 06:44:26.918982', '2024-05-19 06:44:26.918982', 1, NULL),
(9, 'omo', 'omo', '', 'a', 'b', 'b', 'b', 'b', 54836, 'COD', NULL, 'Pending', NULL, 'sharma678298578796', '2024-05-19 06:46:41.809865', '2024-05-19 06:46:41.809865', 1, NULL),
(10, 'omo', 'omo', '', 'и', 'и', 'и', 'b', 'b', 54836, 'COD', NULL, 'Pending', NULL, 'sharma276397185062', '2024-05-19 07:07:44.792208', '2024-05-19 07:07:44.792208', 1, NULL),
(11, 'omo1', 'omo', 'sharmaa@gmail.com', 'и', 'и', 'и', 'b', 'b', 54836, 'COD', NULL, 'Pending', NULL, 'sharma16828762622', '2024-05-19 07:08:29.058965', '2024-05-19 07:08:29.058965', 1, NULL),
(12, 'ommo', 'omo', 'sharmaa1@gmail.com', 'и', 'и', 'и', 'b', 'b', 54836, 'COD', NULL, 'Pending', NULL, 'sharma637196623312', '2024-05-19 14:19:27.128383', '2024-05-19 14:19:27.128383', 1, NULL),
(13, 'Иван', 'Иванов', 'sharmaa1@gmail.com', '+79235658800', 'Алтайский край', 'Барнаул', 'Проспект Ленина', '45', 54836, 'COD', NULL, 'Pending', NULL, 'sharma435312916867', '2024-05-19 14:53:48.980941', '2024-05-19 14:53:48.980941', 1, NULL),
(14, 'Иван', 'Иванов', 'sharmaa1@gmail.com', '+79235658800', 'Алтайский край', 'Барнаул', 'Проспект Ленина', '12', 54836, 'COD', NULL, 'Pending', NULL, 'sharma555409772040', '2024-05-19 15:09:41.276470', '2024-05-19 15:09:41.276470', 1, '45'),
(15, 'Иван', 'Иванов', 'sharmaa1@gmail.com', '+79235658800', 'Алтайский край', 'Барнаул', 'Проспект Ленина', '12', 54836, 'COD', NULL, 'Pending', NULL, 'sharma836710896286', '2024-05-19 15:10:45.811836', '2024-05-19 15:10:45.811836', 1, '45'),
(16, 'Виктор', 'Кира', 'sharmaa1@gmail.com', '+79235658800', 'Алтайский край', 'Барнаул', 'Проспект Ленина', '31', 54836, 'COD', NULL, 'Pending', NULL, 'sharma655059451896', '2024-05-19 15:14:19.211854', '2024-05-19 15:14:19.211854', 1, '52'),
(17, 'omo1', 'Кира', 'sharmaa1@gmail.com', '+79235658800', 'Алтайский край', 'Барнаул', 'Проспект Ленина', '31', 67998, 'COD', NULL, 'Pending', NULL, 'sharma172930488908', '2024-05-21 07:40:14.522188', '2024-05-21 07:40:14.522188', 1, '52');

-- --------------------------------------------------------

--
-- Table structure for table `store_orderitem`
--

CREATE TABLE `store_orderitem` (
  `id` bigint(20) NOT NULL,
  `price` double NOT NULL,
  `quantity` int(11) NOT NULL,
  `order_id` bigint(20) NOT NULL,
  `product_id` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `store_orderitem`
--

INSERT INTO `store_orderitem` (`id`, `price`, `quantity`, `order_id`, `product_id`) VALUES
(1, 27418, 3, 1, 6),
(2, 27418, 4, 2, 6),
(3, 27418, 4, 3, 6),
(4, 27418, 4, 4, 6),
(5, 27418, 4, 5, 6),
(6, 27418, 4, 6, 6),
(7, 27418, 2, 7, 6),
(8, 27418, 2, 8, 6),
(9, 27418, 2, 9, 6),
(10, 27418, 2, 10, 6),
(11, 27418, 2, 11, 6),
(12, 27418, 2, 12, 6),
(13, 27418, 2, 13, 6),
(14, 27418, 2, 14, 6),
(15, 27418, 2, 15, 6),
(16, 27418, 2, 16, 6),
(17, 33999, 2, 17, 11);

-- --------------------------------------------------------

--
-- Table structure for table `store_product`
--

CREATE TABLE `store_product` (
  `id` bigint(20) NOT NULL,
  `slug` varchar(150) NOT NULL,
  `name` varchar(150) NOT NULL,
  `product_image` varchar(100) DEFAULT NULL,
  `small_description` varchar(150) NOT NULL,
  `quantity` int(11) NOT NULL,
  `description` longtext NOT NULL,
  `original_price` double NOT NULL,
  `selling_price` double NOT NULL,
  `status` tinyint(1) NOT NULL,
  `trending` tinyint(1) NOT NULL,
  `tag` varchar(150) NOT NULL,
  `meta_title` varchar(150) NOT NULL,
  `meta_keywords` varchar(150) NOT NULL,
  `meta_description` longtext NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `price` double NOT NULL,
  `digital` tinyint(1) DEFAULT NULL,
  `category_id` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `store_product`
--

INSERT INTO `store_product` (`id`, `slug`, `name`, `product_image`, `small_description`, `quantity`, `description`, `original_price`, `selling_price`, `status`, `trending`, `tag`, `meta_title`, `meta_keywords`, `meta_description`, `created_at`, `price`, `digital`, `category_id`) VALUES
(1, 'Ford', 'Диван-кровать «Фьорд»', 'upload/2024-05-18211538tovar_1_divany.jpg', 'Диван-кровать «Фьорд»', 12, 'Диван Фьорд — один из классических представителей скандинавского стиля. Он минималистичен и привлекателен. Аккуратные строчки, ножки из натурального массива березы и нежная велюровая обивка — продумана каждая деталь.', 0, 37761, 0, 0, 'Ford Диван Couch Диван-кровать «Фьорд»', 'Ford Диван Couch Диван-кровать «Фьорд»', 'Ford Диван Couch Диван-кровать «Фьорд»', 'have', '2024-05-18 14:15:38.139230', 37761, 0, 1),
(2, 'Couch', 'Диван-кровать «Амстердам»', 'upload/2024-05-18211821tovar_2_divany.jpg', 'Диван-кровать «Амстердам»', 50, 'Среди разнообразных видов механизмов трансформации «еврокнижка» остается самым популярным благодаря простоте функционирования, надежности и долговечности. Диван-еврокнижка «Амстердам» — интересная модель, которая станет отличным дополнением обстановки гостиной. Кроме того, она легко трансформируется в просторное и удобное спальное место. Это преимущество механизма «еврокнижка» вы по достоинству оцените, если будете часто раскладывать мебель.', 0, 20300, 0, 0, 'Couch 1', 'Couch', 'couch', 'hsver', '2024-05-18 14:18:21.744747', 20300, 0, 1),
(3, 'Couch', 'Угловой диван-кровать «Кост-А»', 'upload/2024-05-18212026tovar_3_divany.jpg', 'Угловой диван-кровать «Кост-А»', 19, 'Угловой диван-кровать «Кост-А» представляет собой воплощение стиля mid-century modern, прекрасно дополняющего гостиную, холл или кабинет в любом классическом или современном интерьере. Механизм «еврокнижка» позволяет легко превратить диван в полноценное спальное место. Мягкая и прямая поверхность сиденья и спинки, наполненная ППУ, обеспечивает исключительный комфорт во время отдыха и сна.', 0, 39010, 0, 0, 'Couch 1', 'Couch', 'couch', 'have', '2024-05-18 14:20:26.523018', 39010, 0, 1),
(4, 'Arbat', 'Диван-кровать «Арбат»', 'upload/2024-05-18212143tovar_4_divany.jpg', 'Диван-кровать «Арбат»', 21, 'Диван-кровать «Арбат» выдержан в современном стиле. Просторное сиденье не ограничено подлокотниками, поэтому на диване может расположиться большее число людей. Благодаря продуманной конструкции эта модель легко впишется даже в небольшое пространство. В комплект входят четыре декоративные подушки: они сделают вашу гостиную уютной, а отдых на диване – более комфортным.', 0, 29890, 0, 0, 'Arbat Диван Couch Диван-кровать «Арбат»', 'Arbat Диван Couch Диван-кровать «Арбат»', 'Arbat Диван Couch Диван-кровать «Арбат»', 'ds', '2024-05-18 14:21:43.378761', 29890, 0, 1),
(5, 'Amber', 'Кресло «Амбер»', 'upload/2024-05-18212352tovar_1_kresla.jpg', 'Кресло «Амбер»', 50, 'Кресло-маятник с уникальным маятниковым механизмом, который обеспечивает оптимальную амплитуду бесшумного качания.\r\nПри раскачивании, ножки этого кресла остаются неподвижными, сберегая Ваше напольное покрытие от возможных повреждений.\r\nКаркас кресла прочен, надежен и устойчив, способен выдерживать большую нагрузку.', 0, 12201, 0, 0, 'Amber Armchair Кресло «Амбер»', 'Amber Armchair Кресло «Амбер»', 'Amber Armchair Кресло «Амбер»', 'j', '2024-05-18 14:23:52.569171', 12201, 0, 2),
(6, 'Aster', 'Кресло «Астер»', 'upload/2024-05-18212630tovar_2_kresla.jpg', 'Кресло «Астер»', 74, 'Мягкое кресло в теплых природных оттенках и уютных и мягких материалах. Стоит только присесть, как вы окажетесь в его нежных объятиях и вряд ли захотите их покидать.\r\n\r\nЛаконичные округлые формы в сочетании с нежным искусственным мехом станут удобным, а также трендовым дополнением вашего интерьера.', 0, 27418, 0, 0, 'Aster Armchair Кресло «Астер»', 'Aster Armchair Кресло «Астер»', 'Aster Armchair Кресло «Астер»', '5', '2024-05-18 14:26:30.926186', 27418, 0, 2),
(7, 'Willson', 'Кресло «Вилсон»', 'upload/2024-05-18212818tovar_3_kresla.jpg', 'Кресло «Вилсон»', 34, 'Кресла «Вилсон» полностью соответствуют главным требованиям к мебели в стиле минимализма — практичность, функциональность, лаконичность. Кресла имеют механизм трансформации «клик-кляк», что позволяет превращать их в удобные шезлонги для комфортного отдыха.', 0, 41107, 0, 0, 'Willson Armchair Кресло «Вилсон»', 'Willson Armchair Кресло «Вилсон»', 'Willson Armchair Кресло «Вилсон»', 'd', '2024-05-18 14:28:18.838712', 41107, 0, 2),
(8, 'Volana', 'Кресло «Волана»', 'upload/2024-05-18212959tovar_4_kresla.jpg', 'Кресло «Волана»', 40, 'Кресло «Волана» представляет собой уменьшенную версию одноименного дивана. Идея здесь остается прежней – создание идеальной мебели с будуарным настроением и лаконичным внешним видом. Плавность присутствует в каждом элементе модели – спинка нежно обнимает сиденье, незаметно превращаясь в округлые подлокотники, деревянные ножки приподнимают кресло над полом и визуально облегчают всю конструкцию.', 0, 27426, 0, 0, 'Volana Armchair Кресло «Волана»', 'Volana Armchair Кресло «Волана»', 'Volana Armchair Кресло «Волана»', 'df', '2024-05-18 14:29:59.969348', 27426, 0, 2),
(9, 'Prime', 'Кушетка «Прайм»', 'upload/2024-05-18213123tovar_1_kushetka.jpg', 'Кушетка «Прайм»', 52, 'Прайм – односпальная кушетка с ящиками, созданная из первоклассных материалов. Устойчива благодаря деревянным ножкам. Поставить ее можно в любой комнате: спальне, детской, кабинете, гостиной. Стильный дизайн сделает изделие эксклюзивным дополнением интерьера.', 0, 34999, 0, 0, 'Prime Kushetki Кушетка «Прайм»', 'Prime Kushetki Кушетка «Прайм»', 'Prime Kushetki Кушетка «Прайм»', '55', '2024-05-18 14:31:23.974917', 34999, 0, 3),
(10, 'Atiko', 'Кушетка «Атико»', 'upload/2024-05-18213234tovar_2_kushetka.jpg', 'Кушетка «Атико»', 23, 'Яркая современная кушетка «Атико» станет гармоничной частью практически любого интерьера благодаря небольшим размерам. Диван отлично подойдет для офисного пространства, а также будет очаровательно уютным в домашней обстановке. Пухлые декоративные подушки — ненавязчивый штрих дополняющий образ дивана нотами тепла и уюта. Высокие опоры смотрятся стильно, соответствуя модным трендам последних лет.', 0, 31999, 0, 0, 'Atiko Kushetki Кушетка «Атико»', 'Atiko Kushetki Кушетка «Атико»', 'Atiko Kushetki Кушетка «Атико»', 'dd', '2024-05-18 14:32:34.070958', 31999, 0, 3),
(11, 'Cameron', 'Кушетка «Камерон»', 'upload/2024-05-18213350tovar_3_kushetka.jpg', 'Кушетка «Камерон»', 14, 'Элегантная кушетка «Камерон» на высоких деревянных ножках – находка для тех, кто не любит выбирать между комфортом и стилем. Кушетка представляет собой небольшой уютный диванчик с угловой волнообразной спинкой. В отличие от классического дивана, она занимает меньше места и выглядит легко. Модель отлично подойдет для офисного пространства, а также будет очаровательно уютной в домашней обстановке.', 0, 33999, 0, 0, 'Cameron Kushetki Кушетка «Камерон»', 'Cameron Kushetki Кушетка «Камерон»', 'Cameron Kushetki Кушетка «Камерон»', 'sass', '2024-05-18 14:33:50.248774', 33999, 0, 3),
(12, 'Lord', 'Кушетка «Лорд»', 'upload/2024-05-18213516tovar_4_kushetka.jpg', 'Кушетка «Лорд»', 12, 'Лорд – элегантная кушетка со спальным местом с ящиками. В комплектацию входят две подушки. Она универсальна в использовании. Подойдет для мебелирования гостиной, кабинета, детской, созданной в стиле классик, лофт или прованс.', 0, 34999, 0, 0, 'Lord Kushetki Кушетка «Лорд»', 'Lord Kushetki Кушетка «Лорд»', 'Lord Kushetki Кушетка «Лорд»', 'dd', '2024-05-18 14:35:16.281199', 34999, 0, 3);

-- --------------------------------------------------------

--
-- Table structure for table `store_profile`
--

CREATE TABLE `store_profile` (
  `id` bigint(20) NOT NULL,
  `phone` varchar(150) NOT NULL,
  `area` varchar(150) NOT NULL,
  `city` varchar(150) NOT NULL,
  `adress` longtext NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `user_id` int(11) NOT NULL,
  `flatnumb` varchar(150) DEFAULT NULL,
  `email` varchar(50) NOT NULL,
  `housenum` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `store_profile`
--

INSERT INTO `store_profile` (`id`, `phone`, `area`, `city`, `adress`, `created_at`, `user_id`, `flatnumb`, `email`, `housenum`) VALUES
(1, 'a', 'a', 'a', 'a', '2024-05-18 14:35:42.507999', 2, 'a', '', NULL),
(2, '+79235658800', 'Алтайский край', 'Барнаул', 'Проспект Ленина', '2024-05-18 14:36:30.889604', 1, '31', 'sharmaa1@gmail.com', '52');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `auth_group`
--
ALTER TABLE `auth_group`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `auth_group_permissions`
--
ALTER TABLE `auth_group_permissions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `auth_group_permissions_group_id_permission_id_0cd325b0_uniq` (`group_id`,`permission_id`),
  ADD KEY `auth_group_permissio_permission_id_84c5c92e_fk_auth_perm` (`permission_id`);

--
-- Indexes for table `auth_permission`
--
ALTER TABLE `auth_permission`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `auth_permission_content_type_id_codename_01ab375a_uniq` (`content_type_id`,`codename`);

--
-- Indexes for table `auth_user`
--
ALTER TABLE `auth_user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `auth_user_groups`
--
ALTER TABLE `auth_user_groups`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `auth_user_groups_user_id_group_id_94350c0c_uniq` (`user_id`,`group_id`),
  ADD KEY `auth_user_groups_group_id_97559544_fk_auth_group_id` (`group_id`);

--
-- Indexes for table `auth_user_user_permissions`
--
ALTER TABLE `auth_user_user_permissions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `auth_user_user_permissions_user_id_permission_id_14a6b632_uniq` (`user_id`,`permission_id`),
  ADD KEY `auth_user_user_permi_permission_id_1fbb5f2c_fk_auth_perm` (`permission_id`);

--
-- Indexes for table `django_admin_log`
--
ALTER TABLE `django_admin_log`
  ADD PRIMARY KEY (`id`),
  ADD KEY `django_admin_log_content_type_id_c4bce8eb_fk_django_co` (`content_type_id`),
  ADD KEY `django_admin_log_user_id_c564eba6_fk_auth_user_id` (`user_id`);

--
-- Indexes for table `django_content_type`
--
ALTER TABLE `django_content_type`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `django_content_type_app_label_model_76bd3d3b_uniq` (`app_label`,`model`);

--
-- Indexes for table `django_migrations`
--
ALTER TABLE `django_migrations`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `django_session`
--
ALTER TABLE `django_session`
  ADD PRIMARY KEY (`session_key`),
  ADD KEY `django_session_expire_date_a5c62663` (`expire_date`);

--
-- Indexes for table `store_cart`
--
ALTER TABLE `store_cart`
  ADD PRIMARY KEY (`id`),
  ADD KEY `store_cart_product_id_b219c080_fk_store_product_id` (`product_id`),
  ADD KEY `store_cart_user_id_99e99107_fk_auth_user_id` (`user_id`);

--
-- Indexes for table `store_category`
--
ALTER TABLE `store_category`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `store_order`
--
ALTER TABLE `store_order`
  ADD PRIMARY KEY (`id`),
  ADD KEY `store_order_user_id_ae5f7a5f_fk_auth_user_id` (`user_id`);

--
-- Indexes for table `store_orderitem`
--
ALTER TABLE `store_orderitem`
  ADD PRIMARY KEY (`id`),
  ADD KEY `store_orderitem_order_id_acf8722d_fk_store_order_id` (`order_id`),
  ADD KEY `store_orderitem_product_id_f2b098d4_fk_store_product_id` (`product_id`);

--
-- Indexes for table `store_product`
--
ALTER TABLE `store_product`
  ADD PRIMARY KEY (`id`),
  ADD KEY `store_product_category_id_574bae65_fk_store_category_id` (`category_id`);

--
-- Indexes for table `store_profile`
--
ALTER TABLE `store_profile`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `user_id` (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `auth_group`
--
ALTER TABLE `auth_group`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `auth_group_permissions`
--
ALTER TABLE `auth_group_permissions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `auth_permission`
--
ALTER TABLE `auth_permission`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- AUTO_INCREMENT for table `auth_user`
--
ALTER TABLE `auth_user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `auth_user_groups`
--
ALTER TABLE `auth_user_groups`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `auth_user_user_permissions`
--
ALTER TABLE `auth_user_user_permissions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `django_admin_log`
--
ALTER TABLE `django_admin_log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `django_content_type`
--
ALTER TABLE `django_content_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `django_migrations`
--
ALTER TABLE `django_migrations`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `store_cart`
--
ALTER TABLE `store_cart`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `store_category`
--
ALTER TABLE `store_category`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `store_order`
--
ALTER TABLE `store_order`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `store_orderitem`
--
ALTER TABLE `store_orderitem`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `store_product`
--
ALTER TABLE `store_product`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `store_profile`
--
ALTER TABLE `store_profile`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `auth_group_permissions`
--
ALTER TABLE `auth_group_permissions`
  ADD CONSTRAINT `auth_group_permissio_permission_id_84c5c92e_fk_auth_perm` FOREIGN KEY (`permission_id`) REFERENCES `auth_permission` (`id`),
  ADD CONSTRAINT `auth_group_permissions_group_id_b120cbf9_fk_auth_group_id` FOREIGN KEY (`group_id`) REFERENCES `auth_group` (`id`);

--
-- Constraints for table `auth_permission`
--
ALTER TABLE `auth_permission`
  ADD CONSTRAINT `auth_permission_content_type_id_2f476e4b_fk_django_co` FOREIGN KEY (`content_type_id`) REFERENCES `django_content_type` (`id`);

--
-- Constraints for table `auth_user_groups`
--
ALTER TABLE `auth_user_groups`
  ADD CONSTRAINT `auth_user_groups_group_id_97559544_fk_auth_group_id` FOREIGN KEY (`group_id`) REFERENCES `auth_group` (`id`),
  ADD CONSTRAINT `auth_user_groups_user_id_6a12ed8b_fk_auth_user_id` FOREIGN KEY (`user_id`) REFERENCES `auth_user` (`id`);

--
-- Constraints for table `auth_user_user_permissions`
--
ALTER TABLE `auth_user_user_permissions`
  ADD CONSTRAINT `auth_user_user_permi_permission_id_1fbb5f2c_fk_auth_perm` FOREIGN KEY (`permission_id`) REFERENCES `auth_permission` (`id`),
  ADD CONSTRAINT `auth_user_user_permissions_user_id_a95ead1b_fk_auth_user_id` FOREIGN KEY (`user_id`) REFERENCES `auth_user` (`id`);

--
-- Constraints for table `django_admin_log`
--
ALTER TABLE `django_admin_log`
  ADD CONSTRAINT `django_admin_log_content_type_id_c4bce8eb_fk_django_co` FOREIGN KEY (`content_type_id`) REFERENCES `django_content_type` (`id`),
  ADD CONSTRAINT `django_admin_log_user_id_c564eba6_fk_auth_user_id` FOREIGN KEY (`user_id`) REFERENCES `auth_user` (`id`);

--
-- Constraints for table `store_cart`
--
ALTER TABLE `store_cart`
  ADD CONSTRAINT `store_cart_product_id_b219c080_fk_store_product_id` FOREIGN KEY (`product_id`) REFERENCES `store_product` (`id`),
  ADD CONSTRAINT `store_cart_user_id_99e99107_fk_auth_user_id` FOREIGN KEY (`user_id`) REFERENCES `auth_user` (`id`);

--
-- Constraints for table `store_order`
--
ALTER TABLE `store_order`
  ADD CONSTRAINT `store_order_user_id_ae5f7a5f_fk_auth_user_id` FOREIGN KEY (`user_id`) REFERENCES `auth_user` (`id`);

--
-- Constraints for table `store_orderitem`
--
ALTER TABLE `store_orderitem`
  ADD CONSTRAINT `store_orderitem_order_id_acf8722d_fk_store_order_id` FOREIGN KEY (`order_id`) REFERENCES `store_order` (`id`),
  ADD CONSTRAINT `store_orderitem_product_id_f2b098d4_fk_store_product_id` FOREIGN KEY (`product_id`) REFERENCES `store_product` (`id`);

--
-- Constraints for table `store_product`
--
ALTER TABLE `store_product`
  ADD CONSTRAINT `store_product_category_id_574bae65_fk_store_category_id` FOREIGN KEY (`category_id`) REFERENCES `store_category` (`id`);

--
-- Constraints for table `store_profile`
--
ALTER TABLE `store_profile`
  ADD CONSTRAINT `store_profile_user_id_d67604a1_fk_auth_user_id` FOREIGN KEY (`user_id`) REFERENCES `auth_user` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
