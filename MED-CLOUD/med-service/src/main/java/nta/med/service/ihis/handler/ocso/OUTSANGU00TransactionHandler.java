package nta.med.service.ihis.handler.ocso;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.out.Outsang;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class OUTSANGU00TransactionHandler extends ScreenHandler<OcsoServiceProto.OUTSANGU00TransactionRequest, OcsoServiceProto.OUTSANGU00TransactionResponse> {
	private static final Log LOGGER = LogFactory.getLog(OUTSANGU00TransactionHandler.class);

	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	public OcsoServiceProto.OUTSANGU00TransactionResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGU00TransactionRequest request) throws Exception {
		OcsoServiceProto.OUTSANGU00TransactionResponse.Builder response = OcsoServiceProto.OUTSANGU00TransactionResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		// IF: added
		if(DataRowState.ADDED.getValue().equalsIgnoreCase(request.getDataRowState())){
			Double pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode,request.getBunho(),request.getGwa(),request.getIoGubun());
			Double ser = outsangRepository.getOUTSANGU00Ser(hospCode, request.getBunho());
			String resultSang = outsangRepository.getOUTSANGU00ResultSang(hospCode,request.getIoGubun(), request.getGwa(),
					request.getBunho(), request.getFkinp1001(), request.getSangCode(),request.getSangName(), request.getPostModifierName(),
					request.getPreModifierName(),request.getSangStartDate(),request.getSangEndDate(),request.getSangJindanDate(),
					request.getDataGubun(),request.getJuSangYn());
			if(resultSang.equalsIgnoreCase("Y")){
				response.setResultSang(false);
			}else{
				response.setResultSang(true);
			}
			 response.setUpdateResponse(insertOUTSANGU00(request, pkSeq, ser, hospCode));
			 //IF modified
		} else if (DataRowState.MODIFIED.getValue().equalsIgnoreCase(request.getDataRowState())){
			
			String resultSang = outsangRepository.getOUTSANGU00ResultSang(hospCode,request.getIoGubun(), request.getGwa(),
					request.getBunho(), request.getFkinp1001(), request.getSangCode(),request.getSangName(), request.getPostModifierName(),
					request.getPreModifierName(),request.getSangStartDate(),request.getSangEndDate(),request.getSangJindanDate(),
					request.getDataGubun(),request.getJuSangYn());
			if(resultSang.equalsIgnoreCase("Y")){
				response.setResultSang(false);
			}else{
				response.setResultSang(true);
			}
			response.setUpdateResponse(updateOUTSANGU00(request, hospCode));
			// IF deleted
		} else if (DataRowState.DELETED.getValue().equals(request.getDataRowState())){
			if(request.getPkSeq() != null && !request.getPkSeq().isEmpty()){
				String ifDataSendYn = outsangRepository.getIfDataSendYn(hospCode, request.getBunho(), request.getGwa(), request.getIoGubun(), CommonUtils.parseDouble(request.getPkSeq()));
				
				if(request.getDataGubun().equalsIgnoreCase("I") && ifDataSendYn.equalsIgnoreCase("N")){
					response.setUpdateResponse(deleteOUTSANGU00(request, hospCode));
				}else{
					response.setUpdateResponse(updateOUTSANGU00(request, hospCode));
				}
			}
			
		}
		return response.build();
	}
	
	public boolean insertOUTSANGU00(OcsoServiceProto.OUTSANGU00TransactionRequest request,Double pkSeq, Double ser, String hospCode){
			Outsang outsang = new Outsang();
			
			outsang.setSysDate(new Date());
			outsang.setSysId(request.getUserId());
			outsang.setBunho(request.getBunho());
			outsang.setHospCode(hospCode);
			outsang.setGwa(request.getGwa());
			outsang.setIoGubun (request.getIoGubun()); 
			outsang.setPkSeq(pkSeq);
			if(!request.getNaewonDate().isEmpty() && DateUtil.toDate(request.getNaewonDate(),DateUtil.PATTERN_YYMMDD) != null){
				outsang.setNaewonDate (DateUtil.toDate(request.getNaewonDate(),DateUtil.PATTERN_YYMMDD)); 
			}

			outsang.setDoctor (request.getDoctor());
			outsang.setNaewonType (request.getNaewonType());
			if(request.getJubsuNo()!= null && !request.getJubsuNo().isEmpty() ){
				outsang.setJubsuNo(CommonUtils.parseDouble(request.getJubsuNo()));
			}
			if(request.getNaewonDate() != null && !request.getNaewonDate().isEmpty()){
				outsang.setLastNaewonDate (DateUtil.toDate(request.getNaewonDate(),DateUtil.PATTERN_YYMMDD)); 
			}
			outsang.setLastDoctor(request.getDoctor());
			outsang.setLastNaewonType(request.getNaewonType());
			if(request.getJubsuNo()!= null && !request.getJubsuNo().isEmpty() ){
				outsang.setLastJubsuNo(CommonUtils.parseDouble(request.getJubsuNo()));
			}
			if(request.getFkinp1001()!= null && !request.getFkinp1001().isEmpty() ){
				outsang.setFkinp1001(CommonUtils.parseDouble(request.getFkinp1001()));
			}
			outsang.setInputId(request.getUserId());
				outsang.setSer(ser);
			outsang.setSangCode(request.getSangCode());
			outsang.setJuSangYn(request.getJuSangYn());
			outsang.setSangName (request.getSangName());
			if(!request.getSangStartDate().isEmpty() && DateUtil.toDate(request.getSangStartDate(),DateUtil.PATTERN_YYMMDD) != null){
				outsang.setSangStartDate (DateUtil.toDate(request.getSangStartDate(),DateUtil.PATTERN_YYMMDD)); 
			}
			if(!request.getSangEndDate().isEmpty() && DateUtil.toDate(request.getSangEndDate(),DateUtil.PATTERN_YYMMDD) != null){
				outsang.setSangEndDate (DateUtil.toDate(request.getSangEndDate(),DateUtil.PATTERN_YYMMDD)); 
			}
			outsang.setSangEndSayu(request.getSangEndSayu());
			outsang.setPreModifier1 (request.getPreModifier1());
			outsang.setPreModifier2(request.getPreModifier2());
			outsang.setPreModifier3(request.getPreModifier3());
			outsang.setPreModifier4(request.getPreModifier4());
			outsang.setPreModifier5 (request.getPreModifier5());
			outsang.setPreModifier6(request.getPreModifier6());
			outsang.setPreModifier7(request.getPreModifier7());
			outsang.setPreModifier8(request.getPreModifier8());
			outsang.setPreModifier9 (request.getPreModifier9());
			outsang.setPreModifier10(request.getPreModifier10());
			outsang.setPreModifierName(request.getPreModifierName());
			outsang.setPostModifier1(request.getPostModifier1());
			outsang.setPostModifier2(request.getPostModifier2());
			outsang.setPostModifier3(request.getPostModifier3());
			outsang.setPostModifier4(request.getPostModifier4());
			outsang.setPostModifier5(request.getPostModifier5());
			outsang.setPostModifier6(request.getPostModifier6());
			outsang.setPostModifier7(request.getPostModifier7());
			outsang.setPostModifier8(request.getPostModifier8());
			outsang.setPostModifier9(request.getPostModifier9());
			outsang.setPostModifier10(request.getPostModifier10());
			outsang.setPostModifierName(request.getPostModifierName());
			if(!request.getSangJindanDate().isEmpty() && DateUtil.toDate(request.getSangJindanDate(),DateUtil.PATTERN_YYMMDD) != null){
				outsang.setSangJindanDate (DateUtil.toDate(request.getSangJindanDate(),DateUtil.PATTERN_YYMMDD)); 
			}
			outsang.setDataGubun(request.getDataGubun());
			outsangRepository.save(outsang);
			return true;
	}
	
	public boolean updateOUTSANGU00(OcsoServiceProto.OUTSANGU00TransactionRequest request, String hospCode){
			Double ser = 0.0;
			Double pkSeq = 0.0;
			if(request.getSer() != null && !request.getSer().isEmpty()){
				ser = CommonUtils.parseDouble(request.getSer());
			}
			if(request.getPkSeq() != null && !request.getPkSeq().isEmpty()){
				pkSeq = CommonUtils.parseDouble(request.getPkSeq());
			}
			
			Date sangStartDate = new Date();
			Date sangEndDate = new Date();
			Date sangJindanDate = new Date();
			if(!request.getSangStartDate().isEmpty() && DateUtil.toDate(request.getSangStartDate(), DateUtil.PATTERN_YYMMDD) != null){
				sangStartDate = DateUtil.toDate(request.getSangStartDate(), DateUtil.PATTERN_YYMMDD);
			}
			if(!request.getSangEndDate().isEmpty() && DateUtil.toDate(request.getSangEndDate(), DateUtil.PATTERN_YYMMDD) != null){
				sangEndDate = DateUtil.toDate(request.getSangEndDate(), DateUtil.PATTERN_YYMMDD);
			}
			if(!request.getSangJindanDate().isEmpty() && DateUtil.toDate(request.getSangJindanDate(), DateUtil.PATTERN_YYMMDD) != null){
				sangJindanDate = DateUtil.toDate(request.getSangJindanDate(), DateUtil.PATTERN_YYMMDD);
			}
			if(outsangRepository.updateOUTSANGOU00Transaction(request.getUserId(), 
					ser, 
					request.getSangName(), 
					sangStartDate, 
					sangEndDate, 
					request.getSangEndSayu(), 
					request.getJuSangYn(),
					request.getPreModifier1(), 
					request.getPreModifier2(), 
					request.getPreModifier3(), 
					request.getPreModifier4(), 
					request.getPreModifier5(), 
					request.getPreModifier6(), 
					request.getPreModifier7(), 
					request.getPreModifier8(), 
					request.getPreModifier9(), 
					request.getPreModifier10(), 
					request.getPreModifierName(), 
					request.getPostModifier1(), 
					request.getPostModifier2(), 
					request.getPostModifier3(), 
					request.getPostModifier4(), 
					request.getPostModifier5(), 
					request.getPostModifier6(), 
					request.getPostModifier7(), 
					request.getPostModifier8(), 
					request.getPostModifier9(), 
					request.getPostModifier10(), 
					request.getPostModifierName(), 
					sangJindanDate, 
					request.getDataGubun(), 
					request.getBunho(), 
					request.getGwa(), 
					request.getIoGubun(), 
					pkSeq, 
					hospCode) > 0)
			return true;
			return false;
	}
	
	public boolean deleteOUTSANGU00(OcsoServiceProto.OUTSANGU00TransactionRequest request, String hospCode){
		
			Double pkSeq = 0.0;
			if(request.getPkSeq() != null && !request.getPkSeq().isEmpty()){
				pkSeq = CommonUtils.parseDouble(request.getPkSeq());
			}
			if(outsangRepository.deleteOUTSANGU00Transaction(
					request.getBunho(),
					request.getGwa(),
					request.getIoGubun(),
					pkSeq,
					hospCode) > 0)
			return true;
		return false;
	}
	
}
