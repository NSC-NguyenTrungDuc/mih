<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<html>
<body>
	<div id="serverAddress" style="display: none">${serverAddress}</div>
	<div id="hospitalCode" style="display: none">${hospitalCode}</div>
	<div id="deptCode" style="display: none">${deptCode}</div>
	<div id="isWeekMode" style="display: none">${isWeekMode}</div>
	<div id="monthView" style="display:none"><c:url value="calendar"/></div>
	<jsp:include page="../layout/alerts.jsp" />
	<div id='calendar' class="fc fc-ltr"></div>
	
	<script id="week-list" type="text/x-handlebars-template">
		<table class="fc-header" style="width:100%">
			<tbody>
				<tr>
					<td class="fc-header-left">
						<span class="fc-button fc-button-prev fc-state-default fc-corner-left">
							<span class="fc-text-arrow">‹</span>
						</span><span class="fc-button fc-button-next fc-state-default fc-corner-right">
							<span class="fc-text-arrow">›</span>
						</span><span class="fc-header-space"></span><span class="fc-button fc-button-today fc-state-default fc-corner-left fc-corner-right">今日</span>
					</td>
					<td class="fc-header-center">
						<span class="fc-header-title" style="height:43px">
							{{#compare weekList.[0].startDateTime '!=' weekList.[0].endDateTime}}
								<h4>{{weekList.[0].startDateTime}} ~ {{weekList.[0].endDateTime}}</h4>
							{{/compare}}
							{{#compare weekList.[0].startDateTime '==' weekList.[0].endDateTime}}
								<h2>{{weekList.[0].startDateTime}}</h2>
							{{/compare}}
							<div id="startDate" style="display:none">{{weekList.[0].checkedDate}}</div>
							</h4>
						</span>
					</td>
					<td class="fc-header-right">
						<span class="fc-button fc-button-month fc-state-default fc-corner-left">月</span><span class="fc-button fc-button-agendaWeek fc-state-default fc-state-active">週</span><span class="fc-button fc-button-agendaDay fc-state-default fc-corner-right">日</span>
					</td>
				</tr>
			</tbody>
		</table>
		<div class="cl-calendar">
			<table>
				{{#each weekList}}
				<tr>
					<td class="first-day"><div class="row-day">{{checkedDate}}</div><div class="row-date">{{formattedCheckedDate}}</div></td>
					{{#each calendarInfoList}}
						{{#compare status '==' 1}}
							<td class="h-yellow" data-date="{{checkedDate}}" data-time="{{startDateTime}}"><span>{{formattedStartDateTime}}<i class="fa fa-play fa-rotate-270"></i></span></td>
						{{/compare}}
						{{#compare status '==' 2}}
							<td class="h-blue" data-date="{{checkedDate}}" data-time="{{startDateTime}}"><span>{{formattedStartDateTime}}<i class="fa fa-circle"></i></span></td>
						{{/compare}}
						{{#compare status '==' -1}}
							<td></td>
						{{/compare}}
					{{/each}}
				</tr>
				{{/each}}
			</table>
		</div>
	</script>
	<script type="text/javascript" src="<c:url value='/assets/js/calendar-week.js' />"></script>
	<script type="text/javascript" src="<c:url value='/assets/js/MssUtils.js' />"></script>
</body>
</html>