/*
Navicat MySQL Data Transfer

Source Server         : local:3333
Source Server Version : 50528
Source Host           : localhost:3333
Source Database       : ksurat

Target Server Type    : MYSQL
Target Server Version : 50528
File Encoding         : 65001

Date: 2012-12-28 16:36:24
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
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of nomor
-- ----------------------------
INSERT INTO `nomor` VALUES ('1', 'admin', '005-002/NL/X/2012', '/', '1,002', '2,NL', '-,-', '-,-', '3,X,Y', '4,2012,Y', '005-,kiri', 'suratkeluar', 'tahun', 'format surat keluar');
INSERT INTO `nomor` VALUES ('2', 'admin', '005-002/NL/X/2012', '/', '1,002', '2,NL', '-,-', '-,-', '3,X,Y', '4,2012,Y', '005-,kiri', 'suratmasuk', 'bulan', 'format surat masuk');
INSERT INTO `nomor` VALUES ('3', 'admin', '0001/RSCM-K/M/YY', '/', '1,0001', '2,RSCM-K', '-,-', '-,-', '3,X,Y', '4,12,Y', '-,-', 'suratkeluar', 'tahun', 'SURAT KELUAR UNIT');
INSERT INTO `nomor` VALUES ('4', 'admin', '001/RSCM-K/YANMED/M/YY', '/', '1,001', '2,RSCM-K', '3,YANMED', '-,-', '4,X,Y', '5,12,Y', '-,-', 'suratkeluar', 'tahun', 'Surat Keluar Sub Unit Pelayanan Medik');

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
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of suratkeluar
-- ----------------------------
INSERT INTO `suratkeluar` VALUES ('1', 'admin', '1', 'kepada', '001/NakulaLabs/2012', 'judul surat', '2012-09-04', '001-NakulaLabs-2012.doc', 'keterangan surat', '2012-09-04 06:14:21');
INSERT INTO `suratkeluar` VALUES ('2', 'toro', '1', 'Kementrian Kesehatan', '001/RSCM-K/12/12', 'Peminjaman Ruang ICU untuk syuting sinetron', '2012-12-01', 'path', 'Artis luar negeri mau main', '2012-12-28 14:56:32');
INSERT INTO `suratkeluar` VALUES ('3', 'toro', '1', 'adadad', 'dadadad', 'dadadad', '2012-12-28', 'path', 'adadadada', '2012-12-28 14:56:19');
INSERT INTO `suratkeluar` VALUES ('4', 'toro', '1', 'Kera', '001', 'Judul', '2012-12-28', 'path', 'Ketek', '2012-12-28 14:53:02');

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
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of suratmasuk
-- ----------------------------
INSERT INTO `suratmasuk` VALUES ('1', 'toro', '2', '001/NakulaLabs/2012', 'nomor surat', 'judul surat', '2012-09-04', '-', 'kosong', 'keterangan surat', '2012-12-27 10:18:53');
INSERT INTO `suratmasuk` VALUES ('2', 'toro', '1', '23323', '32232', '32323fgdgfh', '2012-12-26', 'tyytytytyt', 'kosong', 'ytytytytyty', '2012-12-27 09:49:04');
INSERT INTO `suratmasuk` VALUES ('3', 'toro', '1', 'RTLE LABS', '1234567890', 'Asalaha asasalsasa\' asasasasa', '2012-12-26', 'Dewq', 'kosong', 'Opop', '2012-12-27 14:39:19');
INSERT INTO `suratmasuk` VALUES ('4', 'toro', '1', 'HAL-2012-999', '2012/BBB/092121', 'Pengumuman', '2012-12-26', 'Bapak', 'kosong', 'Klonengan', '2012-12-26 16:13:46');
INSERT INTO `suratmasuk` VALUES ('5', 'toro', '1', '555/XII/KENCANA', 'NPL/XII/DES/121', 'Penawaran Obat', '2012-12-01', 'Departemen Marketing NPL', 'kosong', 'Lampiran 3 Lembar', '2012-12-27 11:30:04');
INSERT INTO `suratmasuk` VALUES ('6', 'toro', '1trt', 'IT/KENCANA/X11/12/12', 'XII/12/12/BAN', 'Penawaran', '2012-12-27', 'Vendort', 'kosong', 'dsdsdsd', '2012-12-27 14:10:33');
INSERT INTO `suratmasuk` VALUES ('7', 'toro', '1', '2012', '2012', 'GATHERING', '2012-12-27', 'MARKETING', 'kosong', 'LAMPIRAN', '2012-12-27 14:39:52');

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
