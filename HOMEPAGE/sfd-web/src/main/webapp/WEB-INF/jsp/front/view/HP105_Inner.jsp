<%@ page language="java" contentType="text/html;charset=UTF-8"%>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>
<%@ taglib tagdir='/WEB-INF/tags' prefix='sc'%>
<style>
	.form-group1 {
		margin-bottom: 35px;		
	}
		.txtw{
			position:relative;
			padding-left:30px;
		}
		.txtw span{position:absolute; left:0; top:0;}
		.inquyricontact{
			height:250px;
			overflow:auto;
			border: #d2d1d1 solid 1px;
			padding:20px;
			margin:0px 0 30px;
			text-align:left;
			background: #fff;
		}
		input[type=submit]:disabled,
		button:disabled,input[type=submit]:disabled:hover,
		button:disabled:hover {
		   background: #ccc;
			color: #434a54;
			border: none;
			cursor: not-allowed;
		}
		.btn-commit{background:#434a54; border:none;color:#fff;}
	@media only screen and  (max-width: 768px){
		.row{
			margin-left: 0;
			margin-right: 0;
		}
		.col-xs-4,
		.col-xs-8,
		.col-xs-12{
			padding-left:0;
			padding-right: 0;
		}
	}
</style>
<c:url var="testRegistrationUrl" value="/service/registration-for-test-inner" />


<%-- 				<h3><spring:message code="hp105.form.header"/></h3> --%>
				<p style="font-size:20px;font-weight:bold;line-height:1.2;margin:20px 0;">
					<spring:message code="hp105.form.header"/>
				</p>
				<form:form method="post" action="${testRegistrationUrl}" class="form-horizontal" modelAttribute="hospital">
					<div class="row form-group1">
						<div class="col-xs-4">
							<label><spring:message code="hp105.form.label.hospital-name"/></label>
						</div>
						<div class="col-xs-8">
							<form:input type="text" class="form-control" value="${hospital.hospitalName}" path="hospitalName" maxlength="256"/>
							<span class="mss-validate-fr"><form:errors path="hospitalName" cssClass="input-error"/><form:errors/></span>
						</div>
					</div>
					<div class="row form-group1">
						<div class="col-xs-4">
							<label><spring:message code="hp105.form.label.register-name"/></label>
						</div>
						<div class="col-xs-8">
							<form:input type="text" class="form-control" value="${hospital.registerName}" path="registerName" maxlength="256"/>
							<span class="mss-validate-fr"><form:errors path="registerName" cssClass="input-error"/><form:errors/></span>
						</div>
					</div>
					<div class="row form-group1">
						<div class="col-xs-4">
							<label><spring:message code="hp105.form.label.register-email"/></label>
						</div>
						<div class="col-xs-8">
							<form:input class="form-control" type="text" value="${hospital.registerEmail}" path="registerEmail" maxlength="128"/>
							<span class="mss-validate-fr"><form:errors path="registerEmail" cssClass="input-error"/><form:errors/></span>
						</div>
					</div>
					<!-- start new design add locale -->
					<div class="row form-group1">
						<div class="col-xs-4">
							<label><spring:message code="hp105.form.label.account-type"/></label>
						</div>
						<div class="col-xs-8">	
							<form:select value="${hospital.demoFlg}" path="demoFlg" id = "demoFlg">
								 <form:option value= "1" label="デモアカウント" />
                 				 <form:option value= "0" label="本番アカウント" />
               				</form:select>
               				<div id="demoflg-mess" style="margin:8px 0 0; font-size: 12px;"><strong style="color:#24a4d4">デモアカウント</strong>： テスト利用のためのアカウントです。データは1か月間保存いたします。</div>
							<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
							<script>
								jQuery(document).ready(function(){
									jQuery("#demoFlg").change(function () {
										var val = $(this).val();
										if (val == "1") {
											jQuery("#demoflg-mess").html('<strong style="color:#24a4d4">デモアカウント</strong>：テスト利用のためのアカウントです。データは1か月間保存いたします。');
										} else if (val == "0") {
											jQuery("#demoflg-mess").html('<strong style="color:#e18235">本番アカウント</strong>：正式利用の際にはこちらからアカウントを作成してください。');
										} 
									});
								});
							</script>
						</div>
					</div>
					<!--  end new design add locale -->
					<!-- start new design add language -->
					<div class="row form-group1">
						<div class="col-xs-4">
							<label><spring:message code="hp105.form.label.language"/></label>
						</div>
						<div class="col-xs-8">	
							<form:select value="${hospital.language}" path="language">
                 				 <form:option value="JA" label="Japanese" />
                 				 <form:option value="VI" label="VietNamese" />
                 				 <form:option value="EN" label="English" />
               				</form:select>
               				 
								<!--  <input type="text" value="${hospital.locale}" name="locale" maxlength="256">
										<input type="text" value="${hospital.vpnYn}" name="vpnYn" maxlength="256">
								<select name="language" form="languageform">
 									<option value="${hospital.locale}" name="locale">Japanese</option>
  									<option value="${hospital.locale}">VietNamese</option>
  									<option value="${hospital.locale}">English</option>
								</select> -->
						</div>
					</div>
					<!--  end new design add language -->
					<div class="row form-group1">
						<div class="col-xs-4">
							<label><spring:message code="hp105.form.label.captcha"/></label>
						</div>
						<div class="col-xs-8">
							<sc:captcha/>
							<span class="mss-validate-fr" style="top:135px"><c:if test="${not empty captchaError}"><span class="input-error">${captchaError}</span></c:if></span>
						</div>
					</div>
					<div class="row form-group1">
						<div class="col-xs-12">
							<div class="mss-text"><spring:message code="hp105.form.info"/></div>
						</div>
					</div>
                    <div class="row" style="margin-bottom:10px">
						<div class="col-xs-12">
							<div class="inquyricontact lazy">
                           		<p>ソフィアメディクス株式会社（以下「当社」）は、お客様より「医療機関様の登録フォーム」から、お知らせいただいたお客様の医療機関名・氏名・メールアドレスなどの個人情報（以下「個人情報」）を、下記の通りお取り扱いします。</p>
                                <p>&nbsp;</p>
                                <p class="txtw"><span>１．</span>事業者の氏名又は名称<br>
                                ソフィアメディクス株式会社
                                </p>
                                <p class="txtw"><span>２．</span>個人情報保護管理者（若しくはその代理人）の氏名又は職名、所属及び連絡先<br>
                                管理者　：個人情報保護管理責任者<br>
                                連絡先　：ソフィアメディクス株式会社　個人情報問合せ係
                                </p>
                                <p class="txtw"><span>３．</span>個人情報の利用目的<br>
                                当社は、お客様の個人情報を、電子カルテ、パーソナルヘルスレコードアプリケーションならびに関連サービスを利用するにあたってのデモアカウント・本番アカウントの作成及び確認、関連商品に関するお知らせなどに利用させていただき、これらの目的のために記録を残すことがあります。<br>
                                当社は、お客様の個人情報を、これらの目的以外に利用することはありません。
                                </p>
                                <p class="txtw"><span>４．</span>個人情報取扱いの委託<br>
                                当社は事業運営上、前項利用目的の範囲に限って個人情報を外部に委託することがあります。この場合、個人情報保護水準の高い委託先を選定し、個人情報の適正管理・機密保持についての契約を交わし、適切な管理を実施させます。
                                </p>
                                <p class="txtw"><span>５．</span>個人情報の開示等の請求<br>
                                ご本人様は、当社に対してご自身の個人情報の開示等（利用目的の通知、開示、内容の訂正・追加・削除、利用の停止または消去、第三者への提供の停止）に関して、下記の当社問合わせ窓口に申し出ることができます。その際、当社はお客様ご本人を確認させていただいたうえで、合理的な期間内に対応いたします。<br>
                                【お問合せ窓口】<br>
                                　　〒１５０－０００２　東京都渋谷区渋谷３－１３－１１　渋谷ＴＫビル6階<br>
                                　　ソフィアメディクス株式会社　個人情報問合せ係<br>
                                　　ＴＥＬ：０３－４４０５－６０６３（受付時間　10：00～18：00※）<br>
                                　　※土・日曜日、祝日、年末年始、ゴールデンウィーク期間は<br>
                                翌営業日以降の対応とさせていただきます。<br>
                                </p>
                                <p class="txtw"><span>６．</span>個人情報を提供されることの任意性について<br>
                                ご本人様が当社に個人情報を提供されるかどうかは任意によるものです。ただし、必要な項目をいただけない場合、適切な対応ができない場合があります。
                                </p>
                           </div>
                           <div class="checbox" style="text-align: left;">
                           <p>上記個人情報のお取り扱いの内容をご確認のうえ、「同意する」チェックボックスにチェックを入れてください。</p>
                           	<label><input type="checkbox" class="checkbtn" id="checkbox-id"> 上記の個人情報のお取り扱いに同意する</label>
                           </div>
						</div>
					</div>
					<div class="row form-group1">
						<div class="col-xs-4"></div>
						<div class="col-xs-4 center">
							<input type="submit" value="<spring:message code='hp105.form.btn.submit'/>" class="btn-commit"/>
						</div>
					</div>
                    <script>
					$(function() {
						$('.btn-commit').attr('disabled', 'disabled');
					$('#checkbox-id').click(function() {
						if ($(this).is(':checked')) {
							$('.btn-commit').removeAttr('disabled');
						} else {
							$('.btn-commit').attr('disabled', 'disabled');
						}
					});
				});
					</script>
				</form:form>
