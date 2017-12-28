<%@ page language="java" contentType="text/html;charset=UTF-8"%>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>

<div class="col-md-12">
	<div class="entry-content clearfix">
		<c:choose>
			<c:when test="${isSuccess}">
				お客様<br> 
				テストアカウント登録の申し込みをいただき、まことにありがとうございます。<br> 
				<br>
				テストアカウントの利用方法のご説明のメールを３０分以内にお送りいたしますので、ご確認ください。<br>
				ご不明な点をございましたら、support@Karte.Clinic までご連絡を頂戴できますようお願い申し上げます。<br>
			</c:when>
			<c:otherwise>
				お客様<br>
				ご入力のURLは有効期限が経過しており、無効となっております。<br> 
				<a href="${ctx}/service/registration-for-test">こちら</a>から再度ご登録してただきますようお願い申し上げます。
			</c:otherwise>
		</c:choose> 
	</div>
</div>