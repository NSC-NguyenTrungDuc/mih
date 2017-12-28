<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<table class="table table-bordered">
	<thead>
		<tr>
			<td style="background: #ededed" align="center"><label><spring:message code='be030.label.parameter'/></label></td>
			<!-- <td style="background: #ededed"><label></label></td> -->
			<td style="background: #ededed" align="center"><label><spring:message code='be030.label.description'/></label></td>
			<td style="background: #ededed" align="center"><label><spring:message code='be030.label.able.to.applied'/></label></td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td><spring:message code='be030.parameter.hospital.name' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.hospital.name' /></td>
			<td><spring:message code='be030.able.to.be.applied.all' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.patient.name' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.patient.name' /></td>
			<td><spring:message code='be030.able.to.be.applied.all' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.reservation.code' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.reservation.code' /></td>
			<td><spring:message code='be030.able.to.be.applied.all' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.department.name' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.department.name' /></td>
			<td><spring:message code='be030.able.to.be.applied.all' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.reservation.datetime' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.reservation.datetime' /></td>
			<td><spring:message code='be030.able.to.be.applied.all' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.new.doctor.name' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.new.doctor.name' /></td>
			<td><spring:message code='be030.able.to.be.applied.all' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.server.address' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.server.address' /></td>
			<td><spring:message code='be030.able.to.be.applied.all' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.sessionId' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.sessionId' /></td>
			<td><spring:message code='be030.able.to.be.applied.all' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.link.booking.complete' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.link.booking.complete' /></td>
			<td><spring:message
					code='be030.able.to.be.applied.complete.booking' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.link.search.reservation' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.link.search.reservation' /></td>
			<td><spring:message
					code='be030.able.to.be.applied.change.booking' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.link.booking.change.info' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.link.for.booking.change.info' /></td>
			<td><spring:message
					code='be030.able.to.be.applied.booking.change' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.link.booking.change.complete' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.link.for.booking.change.complete' /></td>
			<td><spring:message
					code='be030.able.to.be.applied.booking.change' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.link.for.recipient' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.link.for.recipient' /></td>
			<td><spring:message
					code='be030.able.to.be.applied.cancel.reservation' /></td>
		</tr>
		<tr>
			<td><spring:message code='be030.parameter.link.for.reminder' /></td>
			<!-- <td></td> -->
			<td><spring:message code='be030.des.link.for.reminder' /></td>
			<td><spring:message
					code='be030.able.to.be.applied.reminder' /></td>
		</tr>
	</tbody>
</table>
