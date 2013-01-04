/*
Navicat MySQL Data Transfer

Source Server         : local:3333
Source Server Version : 50528
Source Host           : localhost:3333
Source Database       : ksurat

Target Server Type    : MYSQL
Target Server Version : 50528
File Encoding         : 65001

Date: 2013-01-04 17:26:48
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `disposisi`
-- ----------------------------
DROP TABLE IF EXISTS `disposisi`;
CREATE TABLE `disposisi` (
  `disposisiid` int(11) NOT NULL,
  `agendanomor` varchar(512) COLLATE latin1_general_ci NOT NULL,
  `nomorsurat` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `tanggal` date NOT NULL,
  `sifatsuratid` tinyint(2) NOT NULL,
  `asalsurat` varchar(512) COLLATE latin1_general_ci NOT NULL,
  `diteruskanke` varchar(512) COLLATE latin1_general_ci NOT NULL,
  `catatan` text COLLATE latin1_general_ci,
  `lastedit` date DEFAULT NULL,
  `userid` varchar(50) COLLATE latin1_general_ci DEFAULT NULL,
  PRIMARY KEY (`disposisiid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- ----------------------------
-- Records of disposisi
-- ----------------------------

-- ----------------------------
-- Table structure for `nomor`
-- ----------------------------
DROP TABLE IF EXISTS `nomor`;
CREATE TABLE `nomor` (
  `nomorid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(255) NOT NULL DEFAULT '-',
  `format` varchar(255) NOT NULL DEFAULT '-',
  `batas` varchar(1) NOT NULL DEFAULT '/',
  `nomor` varchar(50) NOT NULL DEFAULT '-,-',
  `organisasi` varchar(50) NOT NULL DEFAULT '-,-',
  `bagian` varchar(50) NOT NULL DEFAULT '-,-',
  `subagian` varchar(50) NOT NULL DEFAULT '-,-',
  `bulan` varchar(50) NOT NULL DEFAULT '-,-,N',
  `tahun` varchar(50) NOT NULL DEFAULT '-,-,N',
  `prefix` varchar(50) NOT NULL DEFAULT '-,-',
  `jenis` enum('suratmasuk','suratkeluar') NOT NULL DEFAULT 'suratkeluar',
  `reset` enum('bulan','tahun') NOT NULL DEFAULT 'tahun',
  `Keterangan` varchar(255) NOT NULL DEFAULT '-',
  PRIMARY KEY (`nomorid`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of nomor
-- ----------------------------
INSERT INTO `nomor` VALUES ('1', 'admin', 'XXX/RSCM-K/KEU/M/YY', '/', '1,001', '2,RSCM-K', '3,KEU', '-,-', '4,X,Y', '5,13,Y', '', 'suratkeluar', 'tahun', 'Surat Keluar Sub Unit Keuangan');
INSERT INTO `nomor` VALUES ('2', 'admin', 'RSCM-K/XXXXX/SM/M/YY', '/', '1,00002', '2,SM', '-,-', '-,-', '3,X,Y', '4,13,Y', 'RSCM-K/,kiri', 'suratmasuk', 'bulan', 'SURAT MASUK');
INSERT INTO `nomor` VALUES ('3', 'admin', 'XXXX/RSCM-K/M/YY', '/', '1,0001', '2,RSCM-K', '-,-', '-,-', '3,X,Y', '4,13,Y', '-,-', 'suratkeluar', 'tahun', 'SURAT KELUAR UNIT');
INSERT INTO `nomor` VALUES ('4', 'admin', 'XXX/RSCM-K/YANMED/M/YY', '/', '1,001', '2,RSCM-K', '3,YANMED', '-,-', '4,X,Y', '5,13,Y', '-,-', 'suratkeluar', 'tahun', 'Surat Keluar Sub Unit Pelayanan Medik');
INSERT INTO `nomor` VALUES ('5', 'admin', 'XXX/RSCM-K/BMP/M/YY', '/', '1,001', '2,RSCM-K', '3,BMP', '-,-', '3,X,Y', '4,13,Y', '-,-', 'suratkeluar', 'tahun', 'Surat Keluar Sub Unit Pengembangan, Mutu & Pemasaran');
INSERT INTO `nomor` VALUES ('6', 'admin', 'XXX/RSCM-K/UMOP/M/YY', '/', '1,001', '2,RSCM-K', '3,UMOP', '-,-', '4,X,Y', '5,13,Y', '-,-', 'suratkeluar', 'tahun', 'Surat Keluar Sub Unit Umum & Operasional');
INSERT INTO `nomor` VALUES ('7', 'admin', 'XXX/RSCM-K/PB/M/YY', '/', '1,001', '2,RSCM-K', '3,PB', '-,-', '4,X,Y', '5,13,Y', '-,-', 'suratkeluar', 'tahun', 'SURAT PENGADAAN BARANG');
INSERT INTO `nomor` VALUES ('8', 'admin', 'XXX/RSCM-K/SK/M/YY', '/', '1,001', '2,RSCM-K', '3,SK', '-,-', '4,X,Y', '5,13,Y', '-,-', 'suratkeluar', 'tahun', 'SURAT KEPUTUSAN');
INSERT INTO `nomor` VALUES ('9', 'admin', 'XXX/RSCM-K/S.KUASA/M/YY', '/', '1,001', '2,RSCM-K', '3,S.KUASA', '-,-', '4,X,Y', '5,13,Y', '-,-', 'suratkeluar', 'tahun', 'SURAT KUASA');
INSERT INTO `nomor` VALUES ('10', 'admin', 'XXX/RSCM-K/SKET/M/YY', '/', '1,001', '2,RSCM-K', '3,SKET', '-,-', '4,X,Y', '5,13,Y', '-,-', 'suratkeluar', 'tahun', 'SURAT KETERANGAN');
INSERT INTO `nomor` VALUES ('11', 'admin', 'XXX/RSCM-K/ST/M/YY', '/', '1,001', '2,RSCM-K', '3,ST', '-,-', '4,X,Y', '5,13,Y', '-,-', 'suratkeluar', 'tahun', 'SURAT TUGAS');
INSERT INTO `nomor` VALUES ('12', 'admin', 'XXX/RSCM-K/MEMO/M/YY', '/', '1,001', '2,RSCM-K', '3,MEMO', '-,-', '4,X,Y', '5,13,Y', '-,-', 'suratkeluar', 'tahun', 'MEMO');

-- ----------------------------
-- Table structure for `perusahaan`
-- ----------------------------
DROP TABLE IF EXISTS `perusahaan`;
CREATE TABLE `perusahaan` (
  `kode` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(255) NOT NULL DEFAULT '-',
  `slogan` varchar(255) NOT NULL DEFAULT '-',
  `alamat` varchar(255) NOT NULL DEFAULT '-',
  `kota` varchar(255) NOT NULL DEFAULT '-',
  `telepon` varchar(255) NOT NULL DEFAULT '-',
  `fax` varchar(255) NOT NULL DEFAULT '-',
  `email` varchar(255) NOT NULL DEFAULT '-',
  `logo` varchar(255) NOT NULL DEFAULT '-',
  `format` varchar(255) NOT NULL DEFAULT '-',
  `size` varchar(255) NOT NULL DEFAULT '-',
  PRIMARY KEY (`kode`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of perusahaan
-- ----------------------------
INSERT INTO `perusahaan` VALUES ('1', 'NakulaLabs', 'anda puas kami lemas', 'www.nakulalabs.com', 'surabaya', '03160516564', '03160516564', 'nakulalabs@gmail.com', '-', 'txt|doc|xls|pdf', '2048');

-- ----------------------------
-- Table structure for `sifatsurat`
-- ----------------------------
DROP TABLE IF EXISTS `sifatsurat`;
CREATE TABLE `sifatsurat` (
  `sifatsuratid` tinyint(2) NOT NULL AUTO_INCREMENT,
  `sifat` varchar(64) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`sifatsuratid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- ----------------------------
-- Records of sifatsurat
-- ----------------------------

-- ----------------------------
-- Table structure for `suratkeluar`
-- ----------------------------
DROP TABLE IF EXISTS `suratkeluar`;
CREATE TABLE `suratkeluar` (
  `keluarid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(255) NOT NULL DEFAULT '-',
  `nomorid` varchar(255) NOT NULL DEFAULT '-',
  `kepada` varchar(255) NOT NULL DEFAULT '-',
  `nomor` varchar(50) NOT NULL DEFAULT '-',
  `judul` varchar(255) NOT NULL DEFAULT '-',
  `tanggal` date NOT NULL DEFAULT '0000-00-00',
  `berkas` varchar(255) NOT NULL DEFAULT '-',
  `keterangan` varchar(255) NOT NULL DEFAULT '-',
  `lastedited` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`keluarid`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of suratkeluar
-- ----------------------------
INSERT INTO `suratkeluar` VALUES ('5', 'toro', '001/RSCM-K/YANMED/M/YY', 'DD', '007/RSCM-K/YANMED/I/12', 'DD', '2013-01-03', 'path', 'DD', '2013-01-03 15:06:57');

-- ----------------------------
-- Table structure for `suratmasuk`
-- ----------------------------
DROP TABLE IF EXISTS `suratmasuk`;
CREATE TABLE `suratmasuk` (
  `masukid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(255) NOT NULL DEFAULT '-',
  `nomorid` varchar(255) NOT NULL DEFAULT '-',
  `nomor` varchar(50) NOT NULL DEFAULT '0',
  `noasal` varchar(50) NOT NULL DEFAULT '0',
  `judul` varchar(255) NOT NULL DEFAULT '-',
  `tanggal` date NOT NULL DEFAULT '0000-00-00',
  `dari` varchar(255) NOT NULL DEFAULT '-',
  `berkas` varchar(255) NOT NULL DEFAULT '-',
  `keterangan` varchar(255) NOT NULL DEFAULT '-',
  `lastedited` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`masukid`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of suratmasuk
-- ----------------------------
INSERT INTO `suratmasuk` VALUES ('9', 'toro', 'RSCM-K/XXXXX/SM/M/YY', 'RSCM-K/00002/SM/I/13', '1234567890', 'Tutup', '2013-01-04', 'From', 'kosong', 'Keterangan', '2013-01-04 16:37:26');

-- ----------------------------
-- Table structure for `user`
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `userid` varchar(255) NOT NULL DEFAULT '-',
  `password` varchar(255) NOT NULL DEFAULT '-',
  `nama` varchar(255) NOT NULL DEFAULT '-',
  `jabatan` varchar(255) NOT NULL DEFAULT '-',
  `divisi` varchar(255) NOT NULL DEFAULT '-',
  `lokasi` varchar(255) NOT NULL DEFAULT '-',
  `level` enum('Admin','User') NOT NULL DEFAULT 'User',
  `aktif` enum('Y','N') NOT NULL DEFAULT 'Y',
  `S0` varchar(9) NOT NULL DEFAULT 'Y;D;D;D;D',
  `S1` varchar(9) NOT NULL DEFAULT 'N;D;N;D;D',
  `S2` varchar(9) NOT NULL DEFAULT 'N;N;N;N;N',
  `S3` varchar(9) NOT NULL DEFAULT 'Y;D;Y;D;D',
  `S4` varchar(9) NOT NULL DEFAULT 'N;D;N;D;D',
  `S5` varchar(9) NOT NULL DEFAULT 'Y;Y;N;N;D',
  `S6` varchar(9) NOT NULL DEFAULT 'Y;Y;N;N;N',
  `S7` varchar(9) NOT NULL DEFAULT 'Y;Y;N;N;N',
  `S8` varchar(9) NOT NULL DEFAULT 'N;D;N;D;D',
  `L0` varchar(9) NOT NULL DEFAULT 'Y;D;D;D;D',
  `L1` varchar(9) NOT NULL DEFAULT 'Y;D;D;D;D',
  `L2` varchar(9) NOT NULL DEFAULT 'Y;D;D;D;D',
  `L3` varchar(9) NOT NULL DEFAULT 'Y;D;D;D;D',
  PRIMARY KEY (`userid`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('pengguna', '8b097b8a86f9d6a991357d40d3d58634', 'nama pengguna pertama', '-', '-', '-', 'User', 'Y', 'Y;D;D;D;D', 'N;D;N;D;D', 'N;N;N;N;N', 'Y;D;Y;D;D', 'N;D;N;D;D', 'Y;Y;N;N;D', 'Y;Y;N;N;N', 'Y;Y;N;N;N', 'N;D;N;D;D', 'Y;D;D;D;D', 'Y;D;D;D;D', 'Y;D;D;D;D', 'Y;D;D;D;D');
INSERT INTO `user` VALUES ('admin', '21232f297a57a5a743894a0e4a801fc3', 'Administrator', 'staff', 'edp', 'kantor pusat', 'Admin', 'Y', 'Y;D;D;D;D', 'Y;D;Y;D;D', 'Y;Y;Y;Y;Y', 'Y;D;Y;D;D', 'Y;D;Y;D;D', 'Y;Y;Y;Y;D', 'Y;Y;Y;Y;Y', 'Y;Y;Y;Y;Y', 'Y;D;Y;D;D', 'Y;D;D;D;D', 'Y;D;D;D;D', 'Y;D;D;D;D', 'Y;D;D;D;D');
