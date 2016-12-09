/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50624
Source Host           : localhost:3306
Source Database       : yunxi

Target Server Type    : MYSQL
Target Server Version : 50624
File Encoding         : 65001

Date: 2016-12-09 11:18:01
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `articles`
-- ----------------------------
DROP TABLE IF EXISTS `articles`;
CREATE TABLE `articles` (
  `article_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `article_title` varchar(255) NOT NULL COMMENT '文章标题',
  `article_content` text NOT NULL COMMENT '文章内容',
  `create_by` bigint(20) NOT NULL COMMENT '创建人',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `article_status` int(11) NOT NULL COMMENT '文章状态 1草稿 2未审核 4审核通过 8审核不通过 16主动删除 32强制删除',
  `read_count` int(11) NOT NULL DEFAULT '0' COMMENT '阅读次数',
  `reply_count` int(11) NOT NULL DEFAULT '0' COMMENT '回复统计',
  `approve_count` int(11) NOT NULL DEFAULT '0' COMMENT '支持统计',
  `oppose_count` int(11) NOT NULL DEFAULT '0' COMMENT '反对统计',
  `modify_time` datetime DEFAULT NULL COMMENT '修改时间',
  `is_high_quality` bit(1) DEFAULT NULL COMMENT '是否精品',
  `is_top` bit(1) DEFAULT NULL COMMENT '是否置顶',
  `category_id` bigint(20) DEFAULT NULL COMMENT '分类',
  PRIMARY KEY (`article_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='文章信息';

-- ----------------------------
-- Records of articles
-- ----------------------------

-- ----------------------------
-- Table structure for `article_replies`
-- ----------------------------
DROP TABLE IF EXISTS `article_replies`;
CREATE TABLE `article_replies` (
  `reply_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `create_by` bigint(20) NOT NULL COMMENT '创建人',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `reply_content` text NOT NULL COMMENT '回复内容',
  `reply_status` int(11) NOT NULL COMMENT '回复状态',
  `reply_type` int(11) NOT NULL COMMENT '回复类型',
  `approve_count` int(11) NOT NULL DEFAULT '0' COMMENT '支持数',
  `oppose_count` int(11) NOT NULL DEFAULT '0' COMMENT '反对数',
  `article_id` bigint(20) NOT NULL COMMENT '文章Id',
  `parent_id` bigint(20) NOT NULL DEFAULT '0' COMMENT '父评论',
  PRIMARY KEY (`reply_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='文章回复';

-- ----------------------------
-- Records of article_replies
-- ----------------------------

-- ----------------------------
-- Table structure for `categories`
-- ----------------------------
DROP TABLE IF EXISTS `categories`;
CREATE TABLE `categories` (
  `category_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `category_name` varchar(20) NOT NULL COMMENT '名称',
  `parent_id` bigint(20) NOT NULL COMMENT '父级菜单',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `category_status` int(11) NOT NULL COMMENT '状态 0禁用 1启用',
  `create_by` bigint(20) NOT NULL COMMENT '创建人',
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='分类信息表';

-- ----------------------------
-- Records of categories
-- ----------------------------

-- ----------------------------
-- Table structure for `common_address`
-- ----------------------------
DROP TABLE IF EXISTS `common_address`;
CREATE TABLE `common_address` (
  `address_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `create_by` bigint(20) NOT NULL COMMENT '创建人',
  `consignee` varchar(255) NOT NULL COMMENT '收件人',
  `mobie_num` varchar(255) NOT NULL COMMENT '手机号',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `sort_index` int(11) NOT NULL COMMENT '排序',
  `address_status` int(11) NOT NULL COMMENT '状态 0禁用 1启用',
  `isdefault` bit(1) NOT NULL COMMENT '是否默认',
  `post_code` varchar(255) DEFAULT NULL COMMENT '邮编',
  `city` varchar(255) NOT NULL COMMENT '市',
  `county` varchar(255) NOT NULL COMMENT '县',
  `address` varchar(255) NOT NULL COMMENT '详细地址',
  `province` int(11) NOT NULL COMMENT '省',
  PRIMARY KEY (`address_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='常用地址';

-- ----------------------------
-- Records of common_address
-- ----------------------------

-- ----------------------------
-- Table structure for `complaints`
-- ----------------------------
DROP TABLE IF EXISTS `complaints`;
CREATE TABLE `complaints` (
  `complaint_id` bigint(20) NOT NULL COMMENT '主键',
  `complaint_title` varchar(255) NOT NULL COMMENT '标题',
  `create_by` bigint(20) NOT NULL COMMENT '创建人',
  `complaint_content` text NOT NULL COMMENT '投诉内容',
  `complaint_status` int(11) NOT NULL COMMENT '状态 0未处理 1已处理',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `complaint_type` int(11) NOT NULL COMMENT '投诉类型 1店铺 2商品 3用户',
  `complaint_object` bigint(20) NOT NULL COMMENT '投诉对象Id',
  `deal_time` datetime DEFAULT NULL COMMENT '处理时间',
  `deal_by` bigint(20) DEFAULT NULL COMMENT '处理人',
  `deal_reply` varchar(255) DEFAULT NULL COMMENT '处理答复',
  PRIMARY KEY (`complaint_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='投诉信息';

-- ----------------------------
-- Records of complaints
-- ----------------------------

-- ----------------------------
-- Table structure for `complaint_attachments`
-- ----------------------------
DROP TABLE IF EXISTS `complaint_attachments`;
CREATE TABLE `complaint_attachments` (
  `attachment_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `complaint_id` bigint(20) NOT NULL COMMENT '投诉Id',
  `attachment_title` varchar(255) NOT NULL COMMENT '附件标题',
  `attachment_url` varchar(255) NOT NULL COMMENT '附件地址',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `create_by` bigint(20) NOT NULL COMMENT '创建人',
  PRIMARY KEY (`attachment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='投诉信息附件';

-- ----------------------------
-- Records of complaint_attachments
-- ----------------------------

-- ----------------------------
-- Table structure for `customers`
-- ----------------------------
DROP TABLE IF EXISTS `customers`;
CREATE TABLE `customers` (
  `customer_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `user_id` bigint(20) NOT NULL COMMENT '用户Id',
  ` identity_card` varchar(20) DEFAULT NULL COMMENT '身份证号',
  `bought_count` int(11) DEFAULT NULL COMMENT '购买总数',
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='买家信息';

-- ----------------------------
-- Records of customers
-- ----------------------------

-- ----------------------------
-- Table structure for `expresses`
-- ----------------------------
DROP TABLE IF EXISTS `expresses`;
CREATE TABLE `expresses` (
  `express_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `express_num` varchar(255) NOT NULL COMMENT '快递单号',
  `express_company` varchar(255) NOT NULL COMMENT '快递公司',
  `create_by` bigint(20) NOT NULL COMMENT '创建人',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`express_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='快递信息';

-- ----------------------------
-- Records of expresses
-- ----------------------------

-- ----------------------------
-- Table structure for `favorites`
-- ----------------------------
DROP TABLE IF EXISTS `favorites`;
CREATE TABLE `favorites` (
  `favorites_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `favorites_type` int(11) DEFAULT NULL COMMENT '类型 1店铺 2商品',
  `object_id` bigint(20) DEFAULT NULL COMMENT '收藏对象Id',
  `create_by` bigint(20) DEFAULT NULL COMMENT '创建人',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `defalut_name` varchar(255) DEFAULT NULL COMMENT '创建人名字',
  `object_title` varchar(255) DEFAULT NULL COMMENT '收藏对象标题',
  `favorites_status` int(11) DEFAULT NULL COMMENT '收藏状态 0已取消 1已关注',
  `object_image` varchar(255) DEFAULT NULL COMMENT '收藏对象图片',
  PRIMARY KEY (`favorites_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='收藏夹';

-- ----------------------------
-- Records of favorites
-- ----------------------------

-- ----------------------------
-- Table structure for `lottery_actives`
-- ----------------------------
DROP TABLE IF EXISTS `lottery_actives`;
CREATE TABLE `lottery_actives` (
  `active_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `prize_id` bigint(20) DEFAULT NULL COMMENT '奖品Id',
  `lottery_id` bigint(20) DEFAULT NULL COMMENT '抽奖活动Id',
  `create_by` bigint(20) DEFAULT NULL COMMENT '抽奖人',
  `create_time` datetime DEFAULT NULL COMMENT '抽奖时间',
  `active_ip` varchar(255) DEFAULT NULL COMMENT '用户IP',
  `active_type` int(11) DEFAULT NULL COMMENT '中将类型',
  `prize_name` varchar(255) DEFAULT NULL COMMENT '奖品名称',
  PRIMARY KEY (`active_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='抽奖行为记录';

-- ----------------------------
-- Records of lottery_actives
-- ----------------------------

-- ----------------------------
-- Table structure for `lottery_draws`
-- ----------------------------
DROP TABLE IF EXISTS `lottery_draws`;
CREATE TABLE `lottery_draws` (
  `lottery_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `lottery_title` varchar(255) DEFAULT NULL COMMENT '活动标题',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `create_by` int(11) DEFAULT NULL COMMENT '创建人',
  `lottery_content` varchar(255) DEFAULT NULL COMMENT '活动内容',
  `shop_id` bigint(20) DEFAULT NULL COMMENT '店铺Id',
  `begin_time` datetime DEFAULT NULL COMMENT '开始时间',
  `end_time` datetime DEFAULT NULL COMMENT '结束时间',
  PRIMARY KEY (`lottery_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='抽奖活动表';

-- ----------------------------
-- Records of lottery_draws
-- ----------------------------

-- ----------------------------
-- Table structure for `messages`
-- ----------------------------
DROP TABLE IF EXISTS `messages`;
CREATE TABLE `messages` (
  `msg_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `msg_title` varchar(255) DEFAULT NULL COMMENT '标题',
  `msg_content` varchar(255) DEFAULT NULL COMMENT '内容',
  `create_by` bigint(20) DEFAULT NULL COMMENT '创建人',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `msg_status` int(11) DEFAULT NULL COMMENT '状态 1未读 2已读 4删除',
  `addressee_id` int(11) DEFAULT NULL COMMENT '收件人',
  `sender` varchar(255) DEFAULT NULL COMMENT '发件人名称',
  `read_time` datetime DEFAULT NULL COMMENT '读取时间',
  `addressee_name` varchar(255) DEFAULT NULL COMMENT '收件人昵称',
  PRIMARY KEY (`msg_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='站内信';

-- ----------------------------
-- Records of messages
-- ----------------------------

-- ----------------------------
-- Table structure for `orders`
-- ----------------------------
DROP TABLE IF EXISTS `orders`;
CREATE TABLE `orders` (
  `order_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `order_num` varchar(255) DEFAULT NULL COMMENT '订单编号',
  `create_by` bigint(20) DEFAULT NULL COMMENT '创建人',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `order_status` int(11) DEFAULT NULL COMMENT '订单状态',
  `pay_time` datetime DEFAULT NULL COMMENT '支付时间',
  `total_amount` decimal(10,0) DEFAULT NULL COMMENT '订单总额',
  `mobie_num` varchar(255) DEFAULT NULL COMMENT '手机号',
  `province` int(11) DEFAULT NULL COMMENT '省',
  `city` varchar(255) DEFAULT NULL COMMENT '市',
  `county` varchar(255) DEFAULT NULL COMMENT '县',
  `address` varchar(255) DEFAULT NULL COMMENT '详细地址',
  `postcode` varchar(255) DEFAULT NULL COMMENT '邮编',
  `express_fee` decimal(18,2) DEFAULT NULL COMMENT '快递费',
  PRIMARY KEY (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='订单信息';

-- ----------------------------
-- Records of orders
-- ----------------------------

-- ----------------------------
-- Table structure for `order_items`
-- ----------------------------
DROP TABLE IF EXISTS `order_items`;
CREATE TABLE `order_items` (
  `order_item_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `product_id` bigint(20) DEFAULT NULL COMMENT '产品Id',
  `product_name` varchar(255) DEFAULT NULL COMMENT '产品名称',
  `unit_price` decimal(10,0) DEFAULT NULL COMMENT '单价',
  `quantity` int(11) DEFAULT NULL COMMENT '数量',
  `promotion_id` bigint(20) DEFAULT NULL COMMENT '优惠信息',
  `total_discount` decimal(10,0) DEFAULT NULL COMMENT '总优惠额度',
  `total_amount` decimal(10,0) DEFAULT NULL COMMENT '商品总额',
  `total_paid` decimal(10,0) DEFAULT NULL COMMENT '实付金额',
  `order_item_status` int(11) DEFAULT NULL COMMENT '状态 ',
  `default_image` varchar(255) DEFAULT NULL COMMENT '默认图片',
  `express_id` int(11) DEFAULT NULL COMMENT '快递信息',
  PRIMARY KEY (`order_item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='订单产品信息';

-- ----------------------------
-- Records of order_items
-- ----------------------------

-- ----------------------------
-- Table structure for `payments`
-- ----------------------------
DROP TABLE IF EXISTS `payments`;
CREATE TABLE `payments` (
  `payment_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `order_id` bigint(20) DEFAULT NULL COMMENT '订单Id',
  `create_by` bigint(20) DEFAULT NULL COMMENT '创建人',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `total_paid` decimal(10,0) DEFAULT NULL COMMENT '实付金额',
  `payment_status` int(11) DEFAULT NULL COMMENT '支付状态',
  `paid_account` varchar(255) DEFAULT NULL COMMENT '付款账号',
  `payee_account` varchar(255) DEFAULT NULL COMMENT '收款账号',
  `trade_num` varchar(255) DEFAULT '' COMMENT '交易流水号',
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='付款信息';

-- ----------------------------
-- Records of payments
-- ----------------------------

-- ----------------------------
-- Table structure for `prizes`
-- ----------------------------
DROP TABLE IF EXISTS `prizes`;
CREATE TABLE `prizes` (
  `prize_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `prize_name` varchar(255) DEFAULT NULL COMMENT '奖品名称',
  `prize_index` int(11) DEFAULT NULL COMMENT '奖品在抽奖程序的显示位置',
  `total_inventory` int(11) DEFAULT NULL COMMENT '奖品库存',
  `create_by` bigint(20) DEFAULT NULL COMMENT '创建人',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `winning_rate` int(11) DEFAULT NULL COMMENT '中奖率',
  `lottery_id` bigint(20) DEFAULT NULL COMMENT '抽奖活动',
  `prize_image` varchar(255) DEFAULT NULL COMMENT '奖品图片位置',
  PRIMARY KEY (`prize_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='奖品信息';

-- ----------------------------
-- Records of prizes
-- ----------------------------

-- ----------------------------
-- Table structure for `products`
-- ----------------------------
DROP TABLE IF EXISTS `products`;
CREATE TABLE `products` (
  `product_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `product_name` varchar(255) NOT NULL COMMENT '商品名称',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `create_by` int(11) NOT NULL COMMENT '创建人',
  `shop_id` bigint(20) NOT NULL COMMENT '店铺Id',
  `category_id` bigint(20) NOT NULL COMMENT '分类Id',
  `unit_price` decimal(10,2) NOT NULL COMMENT '单价',
  `stock_quantity` int(11) NOT NULL COMMENT '总库存数',
  `saled_quantity` int(11) NOT NULL COMMENT '已售数量',
  `product_summary` varchar(255) NOT NULL COMMENT '商品简介',
  `product_content` text NOT NULL COMMENT '详情',
  `default_image` varchar(255) NOT NULL COMMENT '默认图片',
  `product_status` int(11) NOT NULL COMMENT '商品状态 1草稿 2正常 4下架 8删除 16强制下架',
  PRIMARY KEY (`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品信息';

-- ----------------------------
-- Records of products
-- ----------------------------

-- ----------------------------
-- Table structure for `product_comments`
-- ----------------------------
DROP TABLE IF EXISTS `product_comments`;
CREATE TABLE `product_comments` (
  `comment_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `create_by` bigint(20) NOT NULL COMMENT '创建人',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `comment_content` varchar(400) NOT NULL COMMENT '评论内容',
  `comment_status` int(11) NOT NULL COMMENT '评论状态 1未审核 2已审核 4已删除 ',
  `comment_type` int(11) NOT NULL COMMENT '评论类型',
  `product_id` bigint(20) NOT NULL COMMENT '商品Id',
  `parent_id` bigint(20) NOT NULL COMMENT '父节点',
  `approve_count` int(11) NOT NULL COMMENT '赞同总数',
  `opposition_count` int(11) NOT NULL COMMENT '反对总数',
  PRIMARY KEY (`comment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='产品评价信息';

-- ----------------------------
-- Records of product_comments
-- ----------------------------

-- ----------------------------
-- Table structure for `product_comment_images`
-- ----------------------------
DROP TABLE IF EXISTS `product_comment_images`;
CREATE TABLE `product_comment_images` (
  `image_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `image_url` varchar(255) DEFAULT NULL COMMENT '图片路径',
  `comment_id` bigint(20) DEFAULT NULL COMMENT '评价Id',
  `create_by_name` varchar(255) DEFAULT NULL COMMENT '创建人姓名',
  `create_by` bigint(20) DEFAULT NULL COMMENT '创建人Id',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `image_status` int(11) DEFAULT NULL COMMENT '图片状态',
  PRIMARY KEY (`image_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='评论图片';

-- ----------------------------
-- Records of product_comment_images
-- ----------------------------

-- ----------------------------
-- Table structure for `product_images`
-- ----------------------------
DROP TABLE IF EXISTS `product_images`;
CREATE TABLE `product_images` (
  `product_img_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `img_url` varchar(255) NOT NULL COMMENT '图片路径',
  `product_id` bigint(20) NOT NULL COMMENT '商品Id',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `create_by` bigint(20) NOT NULL COMMENT '创建人',
  `sort_index` int(11) NOT NULL COMMENT '排序信息',
  `img_status` int(11) NOT NULL COMMENT '图片状态  1未审核 2已审核 3已删除',
  PRIMARY KEY (`product_img_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='商品图片信息';

-- ----------------------------
-- Records of product_images
-- ----------------------------

-- ----------------------------
-- Table structure for `product_requestions`
-- ----------------------------
DROP TABLE IF EXISTS `product_requestions`;
CREATE TABLE `product_requestions` (
  `question_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `question_title` varchar(255) DEFAULT NULL COMMENT '问题标题',
  `question_content` varchar(255) DEFAULT NULL COMMENT '问题内容',
  `create_by` bigint(20) DEFAULT NULL COMMENT '提问人',
  `create_time` datetime DEFAULT NULL COMMENT '提问时间',
  `product_id` bigint(20) DEFAULT NULL COMMENT '产品Id',
  `reply_by` bigint(20) DEFAULT NULL COMMENT '回复人',
  `reply_content` varchar(255) DEFAULT NULL COMMENT '回复内容',
  `reply_time` datetime DEFAULT NULL COMMENT '回复时间',
  `question_status` int(11) DEFAULT NULL COMMENT '提问状态 1未答复 2已答复 4已删除 ',
  PRIMARY KEY (`question_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='产品提问信息';

-- ----------------------------
-- Records of product_requestions
-- ----------------------------

-- ----------------------------
-- Table structure for `promotions`
-- ----------------------------
DROP TABLE IF EXISTS `promotions`;
CREATE TABLE `promotions` (
  `promotion_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '优惠主键',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `create_by` bigint(20) DEFAULT NULL COMMENT '创建人',
  `promotion_title` varchar(255) DEFAULT NULL COMMENT '活动标题',
  `promotion_content` text COMMENT '活动内容',
  `promotion_status` int(11) DEFAULT NULL COMMENT '优惠状态 1草稿 2正常 4下架',
  `begin_time` datetime DEFAULT NULL COMMENT '开始时间',
  `end_time` datetime DEFAULT NULL COMMENT '结束时间',
  `promotion_type` int(11) DEFAULT NULL COMMENT '优惠类型 1满减 2折扣',
  `min_amount` decimal(10,0) DEFAULT NULL COMMENT '最低消费金额 0表示不限制',
  `promotion_value` decimal(10,0) DEFAULT NULL COMMENT '优惠额度',
  `shop_id` bigint(20) DEFAULT NULL COMMENT '店铺Id 0表示官方活动 其余表示店铺活动',
  `promotion_image` varchar(255) DEFAULT NULL COMMENT '活动预览图片',
  PRIMARY KEY (`promotion_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='优惠活动';

-- ----------------------------
-- Records of promotions
-- ----------------------------

-- ----------------------------
-- Table structure for `security_questions`
-- ----------------------------
DROP TABLE IF EXISTS `security_questions`;
CREATE TABLE `security_questions` (
  `security_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '密保主键',
  `security_title` varchar(255) DEFAULT NULL COMMENT '密保问题',
  `security_answer` varchar(255) DEFAULT NULL COMMENT '密保答案',
  `create_by` int(11) DEFAULT NULL COMMENT '创建人',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`security_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of security_questions
-- ----------------------------

-- ----------------------------
-- Table structure for `shops`
-- ----------------------------
DROP TABLE IF EXISTS `shops`;
CREATE TABLE `shops` (
  `shop_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '店铺Id',
  `shop_name` varchar(50) DEFAULT NULL COMMENT '店铺名称',
  `shop_address` varchar(200) DEFAULT NULL COMMENT '店铺详细地址',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `shop_loge` varchar(50) DEFAULT NULL COMMENT '默认图片',
  `province` int(11) DEFAULT NULL COMMENT '省',
  `city` varchar(255) DEFAULT NULL COMMENT '市',
  `county` varchar(255) DEFAULT NULL COMMENT '县',
  `shop_status` int(11) DEFAULT NULL COMMENT '店铺状态 1未审核 2已审核 3主动关店 4强制关店',
  `permit_image` varchar(50) DEFAULT NULL COMMENT '许可证图片',
  PRIMARY KEY (`shop_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='店铺信息';

-- ----------------------------
-- Records of shops
-- ----------------------------

-- ----------------------------
-- Table structure for `supplies`
-- ----------------------------
DROP TABLE IF EXISTS `supplies`;
CREATE TABLE `supplies` (
  `supply_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `user_id` bigint(20) DEFAULT NULL COMMENT '用户Id',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `identity_card` varchar(20) DEFAULT NULL COMMENT '身份证号',
  `supply_status` int(11) DEFAULT NULL COMMENT '卖家状态 1未审核 2已审核 4已禁用',
  `real_name` varchar(30) DEFAULT NULL COMMENT '真实姓名',
  `identity_card_front` varchar(50) DEFAULT NULL COMMENT '身份证正面',
  `identity_card_bach` varchar(50) DEFAULT NULL COMMENT '身份证反面',
  PRIMARY KEY (`supply_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='卖家信息';

-- ----------------------------
-- Records of supplies
-- ----------------------------

-- ----------------------------
-- Table structure for `users`
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `user_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '自增主键',
  `login_name` varchar(30) NOT NULL COMMENT '登录名',
  `nick_name` varchar(30) DEFAULT NULL COMMENT '昵称',
  `mobie_num` char(11) DEFAULT NULL COMMENT '联系电话',
  `login_pwd` varchar(20) NOT NULL COMMENT '登录密码',
  `email` varchar(50) NOT NULL COMMENT '邮箱',
  `user_status` int(11) NOT NULL COMMENT '用户状态 1手机已验证 2邮箱已验证 4已禁用 ',
  `user_role` int(11) DEFAULT NULL COMMENT '用户角色 1管理员 2买家 4卖家 8客服 ',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `user_point` int(11) NOT NULL COMMENT '用户积分',
  `empirical_value` int(11) NOT NULL COMMENT '用户经验值',
  `user_level` int(11) NOT NULL COMMENT '用户等级',
  `photo_url` varchar(100) DEFAULT NULL COMMENT '用户头像',
  `user_sex` int(11) DEFAULT NULL COMMENT '性别',
  `user_birth` date DEFAULT NULL COMMENT '出生日期',
  `user_description` varchar(255) DEFAULT NULL COMMENT '自我介绍',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户信息';

-- ----------------------------
-- Records of users
-- ----------------------------

-- ----------------------------
-- Table structure for `user_point_actives`
-- ----------------------------
DROP TABLE IF EXISTS `user_point_actives`;
CREATE TABLE `user_point_actives` (
  `active_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `active_type` int(11) DEFAULT NULL COMMENT '积分操作类型 1消耗 2获取',
  `create_by` bigint(20) DEFAULT NULL COMMENT '创建人',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `active_value` int(11) DEFAULT NULL COMMENT '积分值',
  `active_ip` varchar(255) DEFAULT NULL COMMENT '操作IP',
  `active_origin` int(11) DEFAULT NULL COMMENT '动作来源 1登录 2抽奖 ',
  `active_remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`active_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户积分记录';

-- ----------------------------
-- Records of user_point_actives
-- ----------------------------

-- ----------------------------
-- Table structure for `verifications`
-- ----------------------------
DROP TABLE IF EXISTS `verifications`;
CREATE TABLE `verifications` (
  `verification_id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '验证码主键',
  `verification_code` varchar(255) NOT NULL COMMENT '验证码',
  `create_by` bigint(20) NOT NULL COMMENT '创建人',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `failure_time` datetime NOT NULL COMMENT '失效时间',
  `verification_type` int(11) NOT NULL COMMENT '验证类型',
  `verification_status` int(11) NOT NULL COMMENT '验证状态 1未验证 2已验证 4已失效',
  PRIMARY KEY (`verification_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='邮箱/短信验证';

-- ----------------------------
-- Records of verifications
-- ----------------------------
