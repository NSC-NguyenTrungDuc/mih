
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles"%>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>
<!doctype html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7" lang=""> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8" lang=""> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9" lang=""> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js" lang=""> <!--<![endif]-->
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <title>Karte Clinic / Confirm Account</title>
  <meta name="description" content="">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="apple-touch-icon" href="apple-touch-icon.png">
  <link rel="icon" href="favicon.ico" type="image/x-icon">

  <link rel="stylesheet" href="assets/css/bootstrap.min.css">
  <link rel="stylesheet" href="assets/css/bootstrap-theme.min.css">
  <link rel="stylesheet" href="assets/css/font-awesome.min.css">
  <link rel="stylesheet" href="assets/css/animate.css">
  <link rel="stylesheet" href="assets/css/main.css">

  <script src="assets/js/vendor/modernizr-2.8.3-respond-1.4.2.min.js"></script>
</head>
<body>
<!-- BEGIN HEADER -->
<header id="header">
  <!-- BEGIN Logo -->
  <h1 class="logo"><a href="#"><img src="assets/img/logo.png" alt=""></a></h1><!-- END Logo -->
</header><!-- END HEADER -->
<!-- BEGIN Page Section -->
<div class="section-confirm-account">
  <div class="container">
    <div class="row">
      <div class="col-md-4 col-md-offset-2 col-sm-6">
        <div class="confirm-image">
          <img src="assets/img/phr_mockup.png" alt="" class="animated fadeInUp">
        </div>
      </div>
      <div class="col-md-4 col-sm-6">
        <%--<div class="confirm-group-text">--%>
          <%--<img src="assets/img/icon-active-check.png" alt="">--%>
          <%--<h3>PHR account is activated</h3>--%>
          <%--<p>A password has been sent via your email</p>--%>
        <%--</div>--%>
          <tiles:insertAttribute name="body" />
      </div>
    </div>
  </div>
</div><!-- END Page Section -->
<!-- BEGIN Footer -->
<footer id="footer">
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <!-- BEGIN Credit -->
        <div class="credit">
          <!-- BEGIN Copyright Text -->
          <p class="copyright-text">
            KARTE.CLINIC © 2015 All Rights Reserved
          </p><!-- END Copyright Text -->
          <!-- BEGIN Footer Menu -->
          <ul class="footer-menu">
            <li><a href="#">利用規約</a></li>
            <li><a href="#">個人情報保護方針</a></li>
            <li><a href="#">ガイドライン</a></li>
          </ul><!-- END Footer Menu -->
        </div><!-- END Credit -->
      </div>
    </div>
  </div>
</footer><!-- END Footer -->



<script src="assets/js/vendor/jquery-1.11.2.min.js"></script>
<script src="assets/js/vendor/bootstrap.min.js"></script>

<script src="assets/js/scrollReveal.min.js"></script>
<script src="assets/js/responsive-img.min.js"></script>
<script src="assets/js/jquery.mmenu.min.all.js"></script>
<script src="assets/js/jquery.idTabs.min.js"></script>

<script src="assets/js/main.js"></script>

</body>
</html>

