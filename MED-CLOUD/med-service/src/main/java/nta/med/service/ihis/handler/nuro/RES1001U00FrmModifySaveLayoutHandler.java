package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.out.Out1001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out0123Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto.RES1001U00FrmModifySaveLayoutInfo;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class RES1001U00FrmModifySaveLayoutHandler extends ScreenHandler<NuroServiceProto.RES1001U00FrmModifySaveLayoutRequest, NuroServiceProto.RES1001U00FrmModifySaveLayoutResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(RES1001U00FrmModifySaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	@Resource
	private Res0103Repository res0103Repository;
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Resource
	private Out0123Repository out0123Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.RES1001U00FrmModifySaveLayoutRequest request, Vertx vertx, String clientId, String sessionId) {
		for(RES1001U00FrmModifySaveLayoutInfo info : request.getSaveLayoutItemList()){
			if (!StringUtils.isEmpty(info.getJinryoPreDate()) && DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
				return false;
			}
		}
		return true;
	}
	
	@Override
	@Transactional
	public NuroServiceProto.RES1001U00FrmModifySaveLayoutResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.RES1001U00FrmModifySaveLayoutRequest  request) throws Exception {
		NuroServiceProto.RES1001U00FrmModifySaveLayoutResponse.Builder response = NuroServiceProto.RES1001U00FrmModifySaveLayoutResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		String sessionHospCode = getHospitalCode(vertx, sessionId);
		boolean isOtherClinic = false;
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
			isOtherClinic = true;
		}
		Integer result = null;
	  	String errCode = "0";
		String tGubun = "";
		String retVal = "";
		String doctorName = "";
		String tChk = "";
		String tJubsuNo = "";
		Double tPkres1001 = null;
		for(RES1001U00FrmModifySaveLayoutInfo info : request.getSaveLayoutItemList()){
				//get t_gubun and set f_gubun = t_gubun
				 List<String> listObjectTGubun = out1001Repository.getNuroRES1001U00TypeRequest(hospCode, sessionHospCode, info.getBunho(), info.getGwa(), isOtherClinic);
				 if (!CollectionUtils.isEmpty(listObjectTGubun)) {
					 tGubun = listObjectTGubun.get(0);
				 }else{
					 tGubun = "G1" ;
				 }
				 if(DataRowState.ADDED.getValue().equals(info.getRowState())){
					//check doctor
		    		 List<String> listObjectDoctorName = out1001Repository.getDoctorName(hospCode, sessionHospCode, info.getBunho(),
		    				 info.getGwa(), info.getJinryoPreDate(), info.getJinryoPreTime(), isOtherClinic);
		    		 if (!CollectionUtils.isEmpty(listObjectDoctorName)) {
		    			 errCode = "1";
		    			 doctorName = listObjectDoctorName.get(0);
		    			 response.setErrCode(errCode);
		    			 if(!StringUtils.isEmpty(doctorName)){
		 					response.setDoctorName(doctorName);	
		 				 }
		    			 response.setResult(false);
		    			 throw new ExecutionException(response.build());
		                }
		    		 // check t_chk
		    		 tChk = res0103Repository.getNuroRES1001U00CheckingReservation(hospCode, sessionHospCode, info.getDoctor(), 
		    				 info.getJinryoPreDate(), info.getJinryoPreTime(), info.getInputGubun(), isOtherClinic);
				    		if(!StringUtils.isEmpty(tChk)){
				    			if("1".equals(tChk)){
				    				errCode = "2";
				    				response.setErrCode(errCode);
				    				response.setResult(false);
				    				throw new ExecutionException(response.build()); 
					    	    }else if("2".equals(tChk)){
					    			errCode = "3";
					    			response.setErrCode(errCode);
					    			response.setResult(false);
					    			throw new ExecutionException(response.build()); 
					    		}
				    		}
				    //check t_jubsu_no
					 List<Double> listTJubsuNo = out1001Repository.getNuroRES1001U00ReceptionNumber(hospCode, sessionHospCode, info.getBunho(), info.getJinryoPreDate(), isOtherClinic);
						if (CollectionUtils.isEmpty(listTJubsuNo)) {
							 errCode = "4";
							 response.setErrCode(errCode);
							 response.setResult(false);
							 throw new ExecutionException(response.build()); 
						}else{
							 tJubsuNo =listTJubsuNo.get(0).toString();
						}	
					//get	t_res1001_seq
					Double getres1001Seq = CommonUtils.parseDouble(commonRepository.getNextVal("OUT1001_SEQ"));	
					if(getres1001Seq != null){
		    			 tPkres1001 = getres1001Seq;
		    		 }
					//insert OUT1001
		    		 insertOut1001(info,request.getUserId(), tGubun, tJubsuNo, null, hospCode, sessionHospCode, isOtherClinic);
		    		 result = 1;
				 }else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
					//check doctor
		    		 List<String> listObjectDoctorName = out1001Repository.getDoctorName(hospCode, sessionHospCode, info.getBunho(),
		    				 info.getGwa(),info.getJinryoPreDate(),info.getJinryoPreTime(), isOtherClinic);
		    		 if (!CollectionUtils.isEmpty(listObjectDoctorName)) {
		    			 errCode = "5";
		    			 doctorName = listObjectDoctorName.get(0);
		    			 response.setErrCode(errCode);
		    			 if(!StringUtils.isEmpty(doctorName)){
			 					response.setDoctorName(doctorName);	
			 			 }
		    			 response.setResult(false);
		    			 throw new ExecutionException(response.build());
		             }
		    		// check t_chk
		    		 tChk = res0103Repository.getNuroRES1001U00CheckingReservation(hospCode, sessionHospCode, info.getDoctor(), 
		    				 info.getJinryoPreDate(), info.getJinryoPreTime(), info.getInputGubun(), isOtherClinic);
				    	if(!StringUtils.isEmpty(tChk)){
				    		if("1".equals(tChk)){
				    			errCode = "6";
				    			response.setErrCode(errCode);
				    			response.setResult(false);
				    			throw new ExecutionException(response.build()); 
					    }else if("2".equals(tChk)){
					    	  errCode = "7";
					    	  response.setErrCode(errCode);
					    	  response.setResult(false);
					    	  throw new ExecutionException(response.build()); 
					    	 }
				     }
				   //check t_jubsu_no
					List<Double> listTJubsuNo = out1001Repository.getNuroRES1001U00ReceptionNumber(hospCode, sessionHospCode, info.getBunho(), info.getJinryoPreDate(), isOtherClinic);
						if (CollectionUtils.isEmpty(listTJubsuNo)) {
							 errCode = "8";
							 response.setErrCode(errCode);
							 response.setResult(false);
							 throw new ExecutionException(response.build()); 
						}else{
							tJubsuNo = listTJubsuNo.get(0).toString();
						}
					//get	t_res1001_seq
						Double tRes1001Seq = CommonUtils.parseDouble(commonRepository.getNextVal("OUT1001_SEQ"));			
						if(tRes1001Seq != null){
							tPkres1001 = tRes1001Seq;
						}
						
					if("Y".equals(info.getNewrow())){
						//insert Out1001
		    			 insertOut1001(info,request.getUserId(), tGubun, tJubsuNo, tRes1001Seq, hospCode, sessionHospCode, isOtherClinic);
		    			 result = 1;
					}else{
						// check t_chk
						List<String> listTChk = ocs1003Repository.getNuroRES1001U00CheckingHangmogCode(hospCode, info.getBunho(), DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD), info.getGwa(), info.getDoctor());
    		            if (!StringUtils.isEmpty(listTChk)) {
    		            	if(!"N".equals(listTChk.get(0))){
    		            		errCode = "9";
    		            		response.setErrCode(errCode);
    		            		response.setResult(false);
    		            		throw new ExecutionException(response.build()); 
    		            	}
    		            }
    		          //update Out1001
    		            if(isOtherClinic){
    		            	result = out1001Repository.updateRES1001U00FrmModifyReserGrdRES1001SavePerformerIsOtherClinic(request.getUserId(), new Date(),
  		    					  DateUtil.toDate(info.getJinryoPreDate(),DateUtil.PATTERN_YYMMDD),
  		    					  info.getJinryoPreTime(), new BigDecimal(tJubsuNo), hospCode, sessionHospCode, CommonUtils.parseDouble(info.getPkres1001()));
    		            }else{
    		            	result = out1001Repository.updateRES1001U00FrmModifyReserGrdRES1001SavePerformer(request.getUserId(), new Date(),
  		    					  DateUtil.toDate(info.getJinryoPreDate(),DateUtil.PATTERN_YYMMDD),
  		    					  info.getJinryoPreTime(), new BigDecimal(tJubsuNo), hospCode, CommonUtils.parseDouble(info.getPkres1001()));
    		            }
					}	
			     }else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
			    	 List<String> listChkDeleted = ocs1003Repository.getNuroRES1001U00CheckingHangmogCode(hospCode, info.getBunho(), DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD), info.getGwa(), info.getDoctor());
		 	            if (!CollectionUtils.isEmpty(listChkDeleted)) {
		 	            	tChk = listChkDeleted.get(0);	
		 	            	if(!"N".equals(tChk)){
		 	            		errCode = "10";
		 	            		response.setErrCode(errCode);
		 	            		response.setResult(false);
		 	            		throw new ExecutionException(response.build());
		 	             	}
		 	            }
		 	         //delete OUT1001
			 	     if(isOtherClinic){
			 	    	result = out1001Repository.deleteOut1001ByIdIsOtherClinic(hospCode, sessionHospCode, StringUtils.isEmpty(info.getPkout1001()) ? null : new Double(info.getPkout1001()));
		 	           }else{
		 	        	  result = out1001Repository.deleteOut1001ById(hospCode, StringUtils.isEmpty(info.getPkout1001()) ? null : new Double(info.getPkout1001()));
		 	           }
			     }
			}
		response.setResult(result != null && result > 0);
		return response.build();
	}
	private void insertOut1001(RES1001U00FrmModifySaveLayoutInfo info, String userId, String tGubun, String tJubsuNo, Double tPkres1001, String hospCode, String sessionHospCode, boolean isOtherClinic) {
    	
		Out1001 out1001 = new Out1001();
		out1001.setSysDate(new Date());
		out1001.setSysId(userId);
		out1001.setUpdDate(new Date());
		out1001.setUpdId(userId);
		out1001.setHospCode(isOtherClinic ? hospCode : sessionHospCode);
		if(tPkres1001 != null){
			out1001.setPkout1001(tPkres1001);
		}else{
			out1001.setPkout1001(StringUtils.isEmpty(info.getPkout1001()) ? null : new Double(info.getPkout1001()));
		}
		out1001.setReserYn("Y");
		out1001.setNaewonDate(DateUtil.toDate(info.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD));
		out1001.setBunho(info.getBunho());
		out1001.setGwa(info.getGwa());
		out1001.setGubun(tGubun);
		out1001.setDoctor(info.getDoctor());
		out1001.setResChanggu(info.getChanggu());
		out1001.setJubsuTime(info.getJinryoPreTime());
		out1001.setChojae(info.getChojae());
		out1001.setResGubun(info.getResGubun());
		out1001.setNaewonType("0");
		out1001.setJubsuNo(new BigDecimal(tJubsuNo));
		out1001.setResInputGubun(info.getInputGubun());
		out1001.setNaewonYn("N");
		out1001.setJubsuGubun("01");
		out1001.setOutHospCode(sessionHospCode);
		LOGGER.info(out1001.toString());
		out1001Repository.save(out1001);
	}
	
}