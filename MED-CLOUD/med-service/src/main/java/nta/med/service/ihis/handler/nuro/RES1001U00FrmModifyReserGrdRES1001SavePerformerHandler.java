package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.out.Out1001;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class RES1001U00FrmModifyReserGrdRES1001SavePerformerHandler  extends ScreenHandler<NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(RES1001U00FrmModifyReserGrdRES1001SavePerformerHandler.class);
	@Resource
	private Out1001Repository out1001Repository;
	@Resource
	private Res0103Repository res0103Repository;
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	public boolean isValid(NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getJinryoPreDate()) && DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
// client confirm not used
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
//		String hospCode = getHospitalCode(vertx, sessionId);
//		Integer result = null;
//		String tGubun = "";
//		String doctorName = "";
//		String tChk = "";
//		String tJubsuNo = null;
//		Double tRes1001Seq = null;
//		//get t_gubun
//		 	List<String> listObjectTGubun = out1001Repository.getNuroRES1001U00TypeRequest(hospCode, request.getBunho(), request.getGwa());
//		 	if (listObjectTGubun != null && !listObjectTGubun.isEmpty()) {
//		 		tGubun= listObjectTGubun.get(0);
//		 	}else{
//		 		tGubun="G1";
//		 	}
//	    	if(DataRowState.ADDED.getValue().equals(request.getRowstate())) {
//	    		//check doctor
//	    		 List<String> listObjectDoctorName = out1001Repository.getDoctorName(hospCode,request.getBunho(),
//	    				 request.getGwa(),request.getJinryoPreDate(),request.getJinryoPreTime());
//	    		 if (listObjectDoctorName != null && !listObjectDoctorName.isEmpty()) {
//	                    doctorName = listObjectDoctorName.get(0);
//	                    response.setMsg( " 予約時間 [ "+doctorName + "]が重なっています。ご確認ください。");
//	                    response.setResult(false);
//	                    LOGGER.info("RESPONSE: " + response.build().toString());
//	     			    throw new ExecutionException(response.build());
//	                }
//	    		//check t_chk
//	    		 tChk = res0103Repository.getTChkRES1001U00FrmModifyReserGrdRES1001SavePerformer(hospCode, request.getDoctor(),
//	    				 DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD), request.getJinryoPreTime(), request.getInputGubun());
//	    		if(tChk != null && !StringUtils.isEmpty(tChk)){
//	    			if(tChk.equals("1")){
//	    				response.setMsg(" 該当医師の診療スケジュールがありません。ご確認ください。 ");
//	    				response.setResult(false);
//	    				LOGGER.info("RESPONSE: " + response.build().toString());
//	    				throw new ExecutionException(response.build());
//		    		 }else if(tChk.equals("2")){
//		    			 response.setMsg(" 該当日付の予約時間の予約可能人数を超えました。ご確認ください。");
//		    			 response.setResult(false);
//		    			 LOGGER.info("RESPONSE: " + response.build().toString());
//		    			 throw new ExecutionException(response.build());
//		    		 }
//	    		}
//	    		 //check t_jubsu_no
//	    		 List<Double> listTJubsuNo = out1001Repository.getNuroRES1001U00ReceptionNumber(hospCode, request.getBunho(), request.getJinryoPreDate());
//	    		 if (CollectionUtils.isEmpty(listTJubsuNo)) {
//	    				 response.setMsg(" 受付番号の生成に失敗しました。 ");
//	    				 response.setResult(false);
//		    			 LOGGER.info("RESPONSE: " + response.build().toString());
//		    			 throw new ExecutionException(response.build());
//		          }else{
//		        	 tJubsuNo =listTJubsuNo.get(0).toString();
//		          }
//	    		 //get t_res1001_seq
//	    		 Double getres1001Seq = CommonUtils.parseDouble(commonRepository.getNextVal("OUT1001_SEQ"));
//	    		 if(getres1001Seq !=null){
//	    			 tRes1001Seq = getres1001Seq;
//	    		 }
//	    		 //insert OUT1001
//	    		 insertOut1001(request, tGubun, tJubsuNo, null, hospCode);
//	    		 result = 1;
//	    		} else if(DataRowState.MODIFIED.getValue().equals(request.getRowstate())) {
//	    		//check doctor
//	    		 List<String> listObjectDoctorName = out1001Repository.getDoctorName(hospCode, request.getBunho(),
//	    				 request.getGwa(), request.getJinryoPreDate(), request.getJinryoPreTime());
//	    		 if (listObjectDoctorName != null && !listObjectDoctorName.isEmpty()) {
//	                    doctorName = listObjectDoctorName.get(0);
//	                    response.setMsg(" 予約時間[" + doctorName+"]が重なっています。ご確認ください。");
//	                    response.setResult(false);
//	                    LOGGER.info("RESPONSE: " + response.build().toString());
//	                    throw new ExecutionException(response.build());
//	                }
//	    		 // check t_chk
//	    			 tChk = res0103Repository.getNuroRES1001U00CheckingReservation(hospCode, request.getDoctor(), 
//        			request.getJinryoPreDate(), request.getJinryoPreTime(), request.getInputGubun());
//	    			 if(tChk != null && !StringUtils.isEmpty(tChk)){
//	    				 if(tChk.equals("1")){
//		    				 response.setMsg(" 該当医師の診療スケジュールがありません。ご確認ください。");
//		    				 response.setResult(false);
//		    				 LOGGER.info("RESPONSE: " + response.build().toString());
//		    				 throw new ExecutionException(response.build());
//		    			 }else if(tChk.equals("2")){
//		    				 response.setMsg(" 該当日付の予約時間の予約可能人数を超えました。ご確認ください。"); 
//		    				 response.setResult(false);
//		    				 LOGGER.info("RESPONSE: " + response.build().toString());
//		    				 throw new ExecutionException(response.build());
//		    			 }
//	    			 }
//
//	    		 //check t_jubsu_no
//	    		 List<Double> listTJubsuNo = out1001Repository.getNuroRES1001U00ReceptionNumber(hospCode, request.getBunho(), request.getJinryoPreDate());
//			        if (listTJubsuNo == null && listTJubsuNo.isEmpty()) {
//		    			 response.setMsg(" 受付番号の生成に失敗しました。");
//		    			 response.setResult(false);
//		    			 LOGGER.info("RESPONSE: " + response.build().toString());
//		    			 throw new ExecutionException(response.build());
//			          }else{
//			        	  tJubsuNo = listTJubsuNo.get(0).toString();
//			          }
//	    		 //get t_res1001_seq
//			        Double getres1001Seq = CommonUtils.parseDouble(commonRepository.getNextVal("OUT1001_SEQ"));
//			        if(getres1001Seq != null){
//		    			 tRes1001Seq = getres1001Seq;
//		    		 }
//		    		 //inner if 
//		    		 if(request.getNewrow().equals("Y")){
//		    			 //insert Out1001
//		    			 insertOut1001(request, tGubun, tJubsuNo, tRes1001Seq, hospCode);
//		    			 result = 1;
//		    		 }else{
//		    			 // check t_chk
//		    					List<String> listTChk = ocs1003Repository.getNuroRES1001U00CheckingHangmogCode(hospCode, request.getBunho(), DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD), request.getGwa(), request.getDoctor());
//		    		            if (listTChk != null && !listTChk.isEmpty()) {
//		    		            	if(!listTChk.get(0).equals("N")){
//		    		            		response.setMsg(" オーダ内訳が存在するので予約を変更できません。\r\n 診療科に問い合わせてください。 ");
//		    		            		response.setResult(false);
//		    		            		LOGGER.info("RESPONSE: " + response.build().toString());
//		    		            		throw new ExecutionException(response.build());
//		    		            	}
//		    		       }
//		    		//update Out1001
//		    			  result = out1001Repository.updateRES1001U00FrmModifyReserGrdRES1001SavePerformer(request.getQUserId(), new Date(),
//		    					  DateUtil.toDate(request.getJinryoPreDate(),DateUtil.PATTERN_YYMMDD),
//		    	            		request.getJinryoPreTime(), new BigDecimal(tJubsuNo), hospCode, CommonUtils.parseDouble(request.getPkres1001()));
//		    		 }
//		    		 
//	    	} else if(DataRowState.DELETED.getValue().equals(request.getRowstate())) {
//	    		//check t_chk
//	 				List<String> listChkDeleted = ocs1003Repository.getNuroRES1001U00CheckingHangmogCode(hospCode, request.getBunho(), DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD), request.getGwa(), request.getDoctor());
//	 	            if (listChkDeleted != null && !listChkDeleted.isEmpty()) {
//	 	            	tChk = listChkDeleted.get(0);	
//	 	            	if(!tChk.equals("N")){
//	 	            		response.setMsg(" オーダ内訳が存在するので予約を変更できません。\r\n 診療科に問い合わせてください。");
//	 	            		response.setResult(false);
//	 	            		LOGGER.info("RESPONSE: " + response.build().toString());
//	 	            		throw new ExecutionException(response.build());
//	 	             	}
//	 	        //delete OUT1001
//	 	          result = out1001Repository.deleteOut1001ById(hospCode, StringUtils.isEmpty(request.getPkres1001()) ? null : new Double(request.getPkres1001())); 
//	 			}
//	    }
//	    response.setResult(result != null && result > 0);
		return response.build();
	}
	
	private void insertOut1001(NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest request, String tGubun, String tJubsuNo, Double tRes1001Seq, String hospCode) {
    	
    		Out1001 out1001 = new Out1001();
			out1001.setSysDate(new Date());
			out1001.setSysId(request.getQUserId());
			out1001.setUpdDate(new Date());
			out1001.setUpdId(request.getQUserId());
			out1001.setHospCode(hospCode);
			if(tRes1001Seq != null){
				out1001.setPkout1001(tRes1001Seq);
			}else{
				out1001.setPkout1001(StringUtils.isEmpty(request.getPkout1001()) ? null : new Double(request.getPkout1001()));
			}
			out1001.setReserYn("Y");
			out1001.setNaewonDate(DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD));
			out1001.setBunho(request.getBunho());
			out1001.setGwa(request.getGwa());
			out1001.setGubun(tGubun);
			out1001.setDoctor(request.getDoctor());
			out1001.setResChanggu(request.getChanggu());
			out1001.setJubsuTime(request.getJinryoPreTime());
			out1001.setChojae(request.getChojae());
			out1001.setResGubun(request.getChanggu());
			out1001.setNaewonType("0");
			out1001.setJubsuNo(new BigDecimal(tJubsuNo));
			out1001.setResInputGubun(request.getInputGubun());
			out1001.setNaewonYn("N");
			out1001.setJubsuGubun("01");
			LOGGER.info(out1001.toString());
			out1001Repository.save(out1001);
	}
	
}
