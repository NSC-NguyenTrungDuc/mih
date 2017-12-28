package nta.med.service.ihis.handler.nuro;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.out.Out0106;
import nta.med.core.domain.out.Out0113;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.dao.medi.out.Out0113Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class OUT0106U00SaveCommentsHandler extends ScreenHandler<NuroServiceProto.OUT0106U00SaveCommentsRequest, SystemServiceProto.UpdateResponse> {
	
	private static final Log LOG = LogFactory.getLog(OUT0106U00SaveCommentsHandler.class);        
	
	@Resource
    private Out0106Repository out0106Repository;
	@Resource
	private Out0113Repository out0113Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0106U00SaveCommentsRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<NuroModelProto.OUT0106U00GridItemInfo> listItem = request.getGridItemInfoList();
    	 if (!CollectionUtils.isEmpty(listItem)) {
    		 for(NuroModelProto.OUT0106U00GridItemInfo item : listItem){
    			 Double ser = CommonUtils.parseDouble(item.getSer());
    			 if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
    				 Double retVal = out0106Repository.getSerOUT0106U00SaveComments(hospCode, item.getBunho());
    				 if( retVal == null){
    					 response.setResult(false);
    					 throw new ExecutionException(response.build());
    				 }
    				 Out0106 out0106 = new Out0106();
    				 out0106.setSysDate(new Date());
    				 out0106.setSysId(request.getUserId());
    				 out0106.setUpdDate(new Date());
    				 out0106.setUpdId(request.getUserId());
    				 out0106.setHospCode(hospCode);
    				 out0106.setComments(item.getComments());
    				 out0106.setSer(retVal);
    				 out0106.setBunho(item.getBunho());
    				 out0106.setDisplayYn(item.getDisplayYn());
    				 out0106.setCmmtGubun("B");
    				 
    				 out0106Repository.save(out0106);
    			 }else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
    				 out0106Repository.updateOUT0106U00SaveComments(request.getUserId(), new Date(), item.getComments(), item.getDisplayYn(),
    						 hospCode, item.getBunho(), ser);
    			 }else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
    				 out0106Repository.deleteOUT0106U00SaveComments(hospCode, item.getBunho(), ser);
    			 }
    		 }
    		 
    		 List<NuroModelProto.OUT0106U00PatientCommentItemInfo> listPatient = request.getPatientCommentItemInfoList();
    		 if (!CollectionUtils.isEmpty(listPatient)) {
    			 for(NuroModelProto.OUT0106U00PatientCommentItemInfo patient : listPatient){
    				 if(DataRowState.ADDED.getValue().equals(patient.getDataRowState())) {
    					 Date startDate = DateUtil.toDate(patient.getStartDate(), DateUtil.PATTERN_YYMMDD);
    					 Date endDate = DateUtil.toDate(patient.getEndDate(), DateUtil.PATTERN_YYMMDD);
    					 String retVal = out0113Repository.checkExitsOUT0106U00SaveComments(hospCode, patient.getBunho(), patient.getPatientInfo(), startDate);
    					 if("Y".equals(retVal)){
    						 response.setResult(false);
        					 throw new ExecutionException(response.build());
    					 }
    					 
    					 SimpleDateFormat dateFormat = new SimpleDateFormat( "yyyy/MM/dd" );
    					 Calendar cal = Calendar.getInstance();
    				     cal.setTime(dateFormat.parse(patient.getStartDate()) );
						 cal.add(Calendar.DATE, -1);
    					 out0113Repository.updateOUT0106U00SaveComments1(hospCode, cal.getTime(), patient.getBunho(), patient.getPatientInfo());
    					 
    					 Out0113 out0113 = new Out0113();
    					 out0113.setSysDate(new Date());
    					 out0113.setSysId(request.getUserId());
    					 out0113.setUpdDate(new Date());
    					 out0113.setUpdId(request.getUserId());
    					 out0113.setHospCode(hospCode);
    					 out0113.setBunho(patient.getBunho());
    					 out0113.setPatientInfo(patient.getPatientInfo());
    					 out0113.setStartDate(startDate);
    					 out0113.setEndDate(endDate);
    					 out0113.setComments(patient.getComments());
    					 
    					 out0113Repository.save(out0113);
    				 }else if(DataRowState.MODIFIED.getValue().equals(patient.getDataRowState())) {
    					 Date startDate = DateUtil.toDate(patient.getStartDate(), DateUtil.PATTERN_YYMMDD);
    					 Date endDate = DateUtil.toDate(patient.getEndDate(), DateUtil.PATTERN_YYMMDD);
    					 out0113Repository.updateOUT0106U00SaveComments2(patient.getComments(), hospCode, endDate, patient.getBunho(), patient.getPatientInfo(), startDate);
    				 }else if(DataRowState.DELETED.getValue().equals(patient.getDataRowState())) {
    					 SimpleDateFormat dateFormat = new SimpleDateFormat( "yyyy/MM/dd" );
    					 Calendar cal = Calendar.getInstance();
    				     cal.setTime(dateFormat.parse(patient.getStartDate()) );
						 cal.add(Calendar.DATE, -1);
    					 out0113Repository.updateOUT0106U00SaveComments3(hospCode, null, patient.getBunho(), patient.getPatientInfo(), cal.getTime());
    					 
    					 Date startDate = DateUtil.toDate(patient.getStartDate(), DateUtil.PATTERN_YYMMDD);
    					 out0113Repository.deleteOUT0106U00SaveComments(hospCode, patient.getBunho(), patient.getPatientInfo(), startDate);
    				 }
    			 }
    		 }
    	 }
    	response.setResult(true);
		return response.build();
	}

}
