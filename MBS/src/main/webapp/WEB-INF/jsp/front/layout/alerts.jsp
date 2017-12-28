<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<div id="ajax-alert-error" class="alert alert-danger hidden">
	<a href="javascript:void(0);" class="close">&times;</a>
	<span id="ajax-msg-error"></span>
</div>
<div id="ajax-alert-success" class="alert alert-success hidden">
	<a href="javascript:void(0);" class="close">&times;</a>
	<span id="ajax-msg-success"></span>
</div>
<c:if test="${not empty notifications}">
	<c:forEach items="${notifications}" var="notification">
		<c:choose>
			<c:when test="${notification.notificationType eq 'SUCCESS'}">
				<c:set var="alertClass" value="alert-success" />
			</c:when>
			<c:when test="${notification.notificationType eq 'INFO'}">
				<c:set var="alertClass" value="alert-info" />
			</c:when>
			<c:when test="${notification.notificationType eq 'WARN'}">
				<c:set var="alertClass" value="alert-warning" />
			</c:when>
			<c:otherwise>
				<c:set var="alertClass" value="alert-danger" />
			</c:otherwise>
		</c:choose>
		<div class="p-alert alert ${alertClass}" id = '${notification.timeAppear}' >
		   <a href="javascript:void(0);" class="close">&times;</a>
		   ${notification.message}
		</div>
	</c:forEach>
</c:if>
<script type="text/javascript">
	$(document).ready(function() {
		var defaultTime = 5000;
		var timeAppear = $(".p-alert").attr('id');
		if(timeAppear != null && timeAppear!= 'undefined' && timeAppear!= 'null' && timeAppear!= 'NAN'  && timeAppear!= '')
			{
			defaultTime = parseInt(timeAppear);
			}
		timeOut = window.setTimeout(function() {$(".p-alert").addClass('hidden'); }, defaultTime);
		$('a.close').on('click', function(e) {
			var $target = $(e.currentTarget);
			$target.closest('.alert').addClass('hidden');
			clearTimeout(timeOut);
		});
	});
</script>