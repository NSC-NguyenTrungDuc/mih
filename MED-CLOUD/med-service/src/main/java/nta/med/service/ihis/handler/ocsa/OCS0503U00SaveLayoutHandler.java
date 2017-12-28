package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0503;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00ExecuteOCS0503Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0503U00gridOSC0503ListInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class OCS0503U00SaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OCS0503U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private OcsaOCS0503U00ExecuteOCS0503Info ocsaOCS0503U00ExecuteOCS0503Info;
	@Resource
	private  Ocs0503Repository ocs0503Repository;
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private Out1001Repository out1001Repository;
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0503U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean result=processOcs0503(request, hospCode);
		response.setResult(result);
		if(!result){
			throw new ExecutionException(response.build());
		}
		return response.build();
	}
	public boolean processOcs0503(OcsaServiceProto.OCS0503U00SaveLayoutRequest request, String hospCode){
		for(OCS0503U00gridOSC0503ListInfo item : request.getGrdOcs0503ItemList()){
			if(DataRowState.ADDED.getValue().equals(item.getRowState())){
				insertOCS0503(request, hospCode, item);
			}else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())){
				if (!validationCheck(item, hospCode)) {
                    return false;
                }
				Integer modifyYn=ocs0503Repository.updateOCS0503U00(
	        			request.getUserId(),
	        			item.getConsultGwa(), 
	        			item.getConsultDoctor(), 
	        			item.getWangjinYn(), 
	        			item.getSangCode1(), 
	        			item.getSangName1(), 
	        			item.getSangCode2(), 
	        			item.getSangName2(), 
	        			item.getSangCode3(), 
	        			item.getSangName3(), 
	        			item.getReqRemark(), 
	        			DateUtil.toDate(item.getAppDate(), DateUtil.PATTERN_YYMMDD), 
	        			item.getAnswer(),
	        			item.getInOutGubun(),
	        			CommonUtils.parseDouble(item.getFkinp1001()), 
	        			item.getPrintYn(), 
	        			item.getEmerGubun(), 
	        			DateUtil.toDate(item.getRealJinryoDate(), DateUtil.PATTERN_YYMMDD), 
	        			DateUtil.toDate(item.getResultArriveDate(), DateUtil.PATTERN_YYMMDD), 
	        			item.getConfirmYn(), 
	        			item.getAnswerEndYn(), 
	        			DateUtil.toDate(item.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD), 
	        			item.getReserTime(), 
	        			item.getReqEndYn(), 
	        			item.getDisplayYn(), 
	        			item.getConsultSangName(),
	        			hospCode,
	        			CommonUtils.parseDouble(item.getPkocs0503()));
				if(modifyYn <= 0){
					insertOCS0503(request, hospCode, item);
				}
			}else if(DataRowState.DELETED.getValue().equals(item.getRowState())){
				if (!validationCheck(item, hospCode)) {
                    return false;
                }
				ocs0503Repository.deleteOCS0503U01(hospCode,CommonUtils.parseDouble(item.getPkocs0503()));
			}
		}
		return true;
	}
	private void insertOCS0503(
			OcsaServiceProto.OCS0503U00SaveLayoutRequest request,
			String hospCode, OCS0503U00gridOSC0503ListInfo item) {
		Double ocs0503Seq = CommonUtils.parseDouble(commonRepository.getNextVal("OCS0503_SEQ"));
		Ocs0503 ocs0503 = new Ocs0503();
		ocs0503.setSysDate(new Date());
		ocs0503.setSysId(request.getUserId());
		ocs0503.setBunho(item.getBunho());
		ocs0503.setReqDate(DateUtil.toDate(item.getReqDate(), DateUtil.PATTERN_YYMMDD));
		ocs0503.setReqGwa(item.getReqGwa());
		ocs0503.setReqDoctor(item.getReqDoctor());
		ocs0503.setPkocs0503(ocs0503Seq);
		ocs0503.setConsultGwa(item.getConsultGwa());
		ocs0503.setConsultDoctor(item.getConsultDoctor());
		ocs0503.setWangjinYn(item.getWangjinYn());
		ocs0503.setSangCode1(item.getSangCode1());
		ocs0503.setSangName1(item.getSangName1());
		ocs0503.setSangCode2(item.getSangCode2());
		ocs0503.setSangName2(item.getSangName2());
		ocs0503.setSangCode3(item.getSangCode3());
		ocs0503.setSangName3(item.getSangName3());
		ocs0503.setReqRemark(item.getReqRemark());
		ocs0503.setAppDate(DateUtil.toDate(item.getAppDate(), DateUtil.PATTERN_YYMMDD));
		ocs0503.setAnswer(item.getAnswer());
		ocs0503.setInOutGubun(item.getInOutGubun());
		ocs0503.setFkinp1001(CommonUtils.parseDouble(item.getFkinp1001()));
		ocs0503.setPrintYn(item.getPrintYn());
		ocs0503.setEmerGubun(item.getEmerGubun());
		ocs0503.setRealJinryoDate(DateUtil.toDate(item.getRealJinryoDate(), DateUtil.PATTERN_YYMMDD));
		ocs0503.setResultArriveDate(DateUtil.toDate(item.getResultArriveDate(), DateUtil.PATTERN_YYMMDD));
		if(!StringUtils.isEmpty(item.getConfirmYn())){
			ocs0503.setConfirmYn(item.getConfirmYn());
		}else{
			ocs0503.setConfirmYn("N");
		}
		if(!StringUtils.isEmpty(item.getAnswerEndYn())){
			ocs0503.setAnswerEndYn(item.getAnswerEndYn());
		}else{
			ocs0503.setAnswerEndYn("N");
		}
		ocs0503.setJinryoPreDate(DateUtil.toDate(item.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD) );
		ocs0503.setReserTime(item.getReserTime());
		ocs0503.setReqEndYn(item.getReqEndYn());
		ocs0503.setDisplayYn(item.getDisplayYn());
		ocs0503.setHospCode(hospCode);
		ocs0503.setConsultSangName(item.getConsultSangName());
		ocs0503.setUpdDate(new Date());
		ocs0503.setUpdId(request.getUserId());
		ocs0503Repository.save(ocs0503);
	}
	
	private boolean validationCheck(OCS0503U00gridOSC0503ListInfo item, String hospCode){
		String orderYn = out1001Repository.getFnOutCheckNaewonYn(hospCode, CommonUtils.parseDouble(item.getConsultFkout1001()));
		if("O".equalsIgnoreCase(orderYn)){
			return false;
		}
		return true;
	}
}
