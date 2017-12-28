<%@ page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>

<script>
		var profileId = '${profile_id}';
		var URL = '${url}'+"api/profiles/" + profileId;
	 	var prhToken = '${phr_token}';
	 	var hospitalLocale = '<%=MssContextHolder.getHospitalLocale()%>';	 	
</script>

 <div class="block">
                                <div class="block-header">
                                    <h3 class="block-title"><i class="fa fa-user"></i> <spring:message code="fed01.basicInfo" /></h3>
                                    <span class="toggle opened">&nbsp;</span>
                                </div>
                                <div class="block-content" id = "profile-info">
                                    <!-- BEGIN Row -->
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="cgroup">
                                                <label class="label"><spring:message code="fed01.basicInfo.fullname" /></label>
                                                <div class="info-text"></div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6" id = "name-kana">
                                            <div class="cgroup">
                                                <label class="label"><spring:message code="fed01.basicInfo.fullnameKana" /></label>
                                                <div class="info-text"></div>
                                            </div>
                                        </div>
                                    </div><!-- END Row -->
                                    <!-- BEGIN Row -->
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="cgroup">
                                                <label class="label"><spring:message code="fed01.basicInfo.gender" /></label>
                                                <div class="info-text"> <span class="nofocus"></span></div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="cgroup">
                                                <label class="label"><spring:message code="fed01.basicInfo.birthday" /></label>
                                                <div class="info-text"> <span class="nofocus">/</span>  <span class="nofocus">/</span> </div>
                                            </div>
                                        </div>
                                    </div><!-- END Row -->
                                    <!-- BEGIN Row -->
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="cgroup">
                                                <label class="label"><spring:message code="fed01.basicInfo.prefecture" /></label>
                                                <div class="info-text"></div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="cgroup">
                                                <label class="label"><spring:message code="fed01.basicInfo.city" /></label>
                                                <div class="info-text"></div>
                                            </div>
                                        </div>
                                    </div><!-- END Row -->
                                    <!-- BEGIN Row -->
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="cgroup">
                                                <label class="label"><spring:message code="fed01.basicInfo.address" /></label>
                                                <div class="info-text"> </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="cgroup">
                                                <label class="label"><spring:message code="fed01.basicInfo.occupation" /></label>
                                                <div class="info-text"></div>
                                            </div>
                                        </div>
                                    </div><!-- END Row -->
                                </div>
                            	</div><!-- END Block -->
                            	<div id = "data-not-found" style="display:none;text-align: center;">
                            		<h3><span> <spring:message code="general.not.data.found" /></span></h3>
                            	</div>
             <div class="block">
                                <div class="block-header">
                                    <h3 class="block-title"><i class="fa fa-clock-o"></i> <spring:message code="fed01.insuranceHistory" /></h3>
                                    <span class="toggle opened">&nbsp;</span>
                                </div>
                                <div class="block-content">
                                	 <div class="table-responsive">
			                                <table id="tableAjax"  class="table table-bordered table-striped table-green">
			                                    <thead>
			                                      <tr>
			                                        <th></th>
			                                        <th><spring:message code="fed01.insuranceHistory.examDateTime" /></th>
			                                        <th><spring:message code="fed01.insuranceHistory.insuranceLink" /></th>
			                                      </tr>
			                                    </thead>
			                                </table>
                              		 </div>
                                </div>
                           </div>



  <script>
  jQuery.fn.dataTableExt.oApi.fnPagingInfo = function ( oSettings )
	{
		return {
			"iStart":         oSettings._iDisplayStart,
			"iEnd":           oSettings.fnDisplayEnd(),
			"iLength":        oSettings._iDisplayLength,
			"iTotal":         oSettings.fnRecordsTotal(),
			"iFilteredTotal": oSettings.fnRecordsDisplay(),
			"iPage":          oSettings._iDisplayLength === -1 ?
				0 : Math.ceil( oSettings._iDisplayStart / oSettings._iDisplayLength ),
			"iTotalPages":    oSettings._iDisplayLength === -1 ?
				0 : Math.ceil( oSettings.fnRecordsDisplay() / oSettings._iDisplayLength )
		};
	};

$(document).ready(function() {
 	if(profileId == '' || prhToken == '')
		{
		 $('#profile-info').remove();
		 $('#data-not-found').show();
		}
 	if(hospitalLocale == "en" || hospitalLocale == "vi")
 		{
 		$("#name-kana").hide();
 		}
 	 var labelMale = '<spring:message code="general.label.male" />';
	 var labelFemale = '<spring:message code="general.label.female" />';
	 var url =  '${url}'+"api/profiles/"  + "standard_profile/"+ profileId + "?token=" + prhToken;
	 getBasicProfileInformation(url,labelMale,labelFemale);
	 var language = {
			    "emptyTable":    '<spring:message code="general.not.data.found" />',
			    "info":           '<spring:message code="general.info.info" />',
			    "infoEmpty":      '<spring:message code="general.info.infoEmpty" />',
			    "infoFiltered":   "(filtered from _MAX_ total entries)",
			    "error"		  :   '<spring:message code="general.error.system" />',
			    "infoPostFix":    "",
			    "thousands":      ",",
			    "lengthMenu":     '<spring:message code="general.info.sLengthMenu" />',
			    "loadingRecords": "Loading...",
			    "processing":     "Processing...",
			    "search":         "Search:",
			    "zeroRecords":    "No matching records found",
			    "paginate": {
			        "first":      '<spring:message code="general.nav.button.first" />',
			        "last":       '<spring:message code="general.nav.button.last" />',
			        "next":       '<spring:message code="general.nav.button.next" />',
			        "previous":   '<spring:message code="general.nav.button.previous" />'
			    },
			    "aria": {
			        "sortAscending":  ": activate to sort column ascending",
			        "sortDescending": ": activate to sort column descending"
			    }
			}
	 fillDataToTable(language);
		} );

  </script>
  <script type="text/javascript" src="<c:url value='/assets/js/doctor/ProfileInformation.js'/>" ></script>
