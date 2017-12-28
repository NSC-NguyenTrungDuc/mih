<%@ page language="java" contentType="text/html;charset=UTF-8"%>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>
<%@ taglib tagdir='/WEB-INF/tags' prefix='sc'%>

<c:url var="testRegistrationUrl" value="/service/registration-for-test" />

<div class="col-md-12">
	<div class="entry-content clearfix">
		<div class="form-register">
			
<!-- 			<div class="col-md-4 left-form"> -->
<!-- 				<h3>医療機関様の登録</h3> -->
<!-- 				<p> -->
<!-- 					テストアカウント設定画面<br> こちらから医療機関様のためのクラウド電子カルテ<br> -->
<!-- 					のテストアカウントを<br> 設定していただくことができます -->
<!-- 				</p> -->
<!-- 			</div> -->
			
			<div class="col-md-8 right-form">
				<h3>メールをご確認ください</h3>
				<form action="">
					<p>お客様</p>
					<p>テストアカウント登録のお申込みをいただき、まことにありがとうございます。</p>
					<br>
					<p>ご確認のメールをご入力いただきましたメールアドレスに自動的にお送りしておりますので、ご確認ください。</p>
					<p>
						ご不明な点がございましたら、<a href="mailto:Support@Karte.Clinic">Support@Karte.Clinic</a>
						までご連絡を頂戴できれば幸いでございます。
					</p>
				</form>
			</div>
		</div>
	</div>
</div>