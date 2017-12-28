package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0503;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OcsaOCS0503U01GrdOCS0503ListInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class OCS0503U01SaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OCS0503U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	
    @Resource
    private Ocs0503Repository ocs0503Repository;
    
    @Override
    public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0503U01SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<OcsaOCS0503U01GrdOCS0503ListInfo> infoList = request.getSaveListList();
		if(!CollectionUtils.isEmpty(infoList)) {
			String hospCode = getHospitalCode(vertx, sessionId);
			String userId = request.getUserId();
			for(OcsaOCS0503U01GrdOCS0503ListInfo info : infoList) {
				if(DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
					if(!insertOcs0503(info, hospCode, userId)) {
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
					if(!updateOCS0503(info, hospCode, userId)) {
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				} else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
					if(!deleteOCS0503(info, hospCode)) {
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				}
			}
		}
		response.setResult(true);
		return response.build();
    }
    
    public boolean insertOcs0503(OcsaOCS0503U01GrdOCS0503ListInfo request, String hospCode, String userId) throws Exception{
		Ocs0503 ocs0503 = new Ocs0503();

		Date date = new Date();
		Double pkocs0503 = ocs0503Repository.getSeqOcs0503();
		ocs0503.setSysDate(date);
		ocs0503.setSysId(userId);
		ocs0503.setBunho(request.getBunho());
		ocs0503.setReqDate(DateUtil.toDate(request.getReqDate(), DateUtil.PATTERN_YYMMDD));
		ocs0503.setReqGwa(request.getReqGwa());
		ocs0503.setReqDoctor(request.getReqDoctor());
		if(pkocs0503 != null){
    	  ocs0503.setPkocs0503(pkocs0503);
		}
		ocs0503.setConsultGwa(request.getConsultGwa());
		ocs0503.setConsultDoctor(StringUtils.isEmpty(request.getConsultDoctor()) ? null : request.getConsultDoctor());
		ocs0503.setWangjinYn(StringUtils.isEmpty(request.getWangjinYn()) ? null : request.getWangjinYn());
		ocs0503.setSangCode1(StringUtils.isEmpty(request.getSangCode1()) ? null : request.getSangCode1());
		ocs0503.setSangName1(StringUtils.isEmpty(request.getSangName1()) ? null : request.getSangName1());
		ocs0503.setSangCode2(StringUtils.isEmpty(request.getSangCode2()) ? null : request.getSangCode2());
		ocs0503.setSangName2(StringUtils.isEmpty(request.getSangName2()) ? null : request.getSangName2());
		ocs0503.setSangCode3(StringUtils.isEmpty(request.getSangCode3()) ? null : request.getSangCode3());
		ocs0503.setSangName3(StringUtils.isEmpty(request.getSangName3()) ? null : request.getSangName3());
		ocs0503.setReqRemark(StringUtils.isEmpty(request.getReqRemark()) ? null : request.getReqRemark());
    	ocs0503.setAppDate(DateUtil.toDate(request.getAppDate(), DateUtil.PATTERN_YYMMDD));
		ocs0503.setAnswer(StringUtils.isEmpty(request.getAnswer()) ? null : request.getAnswer());
		ocs0503.setInOutGubun(StringUtils.isEmpty(request.getInOutGubun()) ? null : request.getInOutGubun());
		ocs0503.setFkinp1001(CommonUtils.parseDouble(request.getFkinp1001()));
		ocs0503.setPrintYn(StringUtils.isEmpty(request.getPrintYn()) ? null : request.getPrintYn());
		ocs0503.setEmerGubun(StringUtils.isEmpty(request.getEmerGubun()) ? null : request.getEmerGubun());
		ocs0503.setRealJinryoDate(DateUtil.toDate(request.getRealJinryoDate(), DateUtil.PATTERN_YYMMDD));
		ocs0503.setResultArriveDate(DateUtil.toDate(request.getResultArriveDate(), DateUtil.PATTERN_YYMMDD));
		if(request.getConfirmYn() == null){
    		ocs0503.setConfirmYn("N");
		}else{
			ocs0503.setConfirmYn(request.getConfirmYn());
		}
		if(request.getAnswerEndYn() == null){
    		ocs0503.setAnswerEndYn("N");
		}else{
			ocs0503.setAnswerEndYn(request.getAnswerEndYn());
		}
		ocs0503.setJinryoPreDate(DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD));
		ocs0503.setAmpmGubun(StringUtils.isEmpty(request.getAmpmGubun()) ? null : request.getAmpmGubun());
		ocs0503.setReqEndYn(StringUtils.isEmpty(request.getReqEndYn()) ? null : request.getReqEndYn());
		ocs0503.setDisplayYn(StringUtils.isEmpty(request.getDisplayYn()) ? null : request.getDisplayYn());
		ocs0503.setConsultSangName(StringUtils.isEmpty(request.getConsultSangName()) ? null : request.getConsultSangName());
		ocs0503.setHospCode(hospCode);
		ocs0503Repository.save(ocs0503);
		return true;
    }
    
    public boolean updateOCS0503(OcsaOCS0503U01GrdOCS0503ListInfo request, String hospCode, String userId){
		Double fkinp1001 = 0.0;
		Double pkocs0503 = 0.0;
		if(request.getFkinp1001()!= null && !request.getFkinp1001().isEmpty()){
			fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		}
		if(request.getPkocs0503()!= null&& !request.getPkocs0503().isEmpty()){
			pkocs0503 = CommonUtils.parseDouble(request.getPkocs0503());
		}
		Integer result = ocs0503Repository.updateOCS0503U01(
    			userId,
    			request.getConsultGwa(), 
    			StringUtils.isEmpty(request.getConsultDoctor()) ? null : request.getConsultDoctor(), 
    			StringUtils.isEmpty(request.getWangjinYn()) ? null : request.getWangjinYn(), 
    			StringUtils.isEmpty(request.getSangCode1()) ? null : request.getSangCode1(), 
    			StringUtils.isEmpty(request.getSangName1()) ? null : request.getSangName1(), 
    			StringUtils.isEmpty(request.getSangCode2()) ? null : request.getSangCode2(), 
    			StringUtils.isEmpty(request.getSangName2()) ? null : request.getSangName2(), 
    			StringUtils.isEmpty(request.getSangCode3()) ? null : request.getSangCode3(), 
    			StringUtils.isEmpty(request.getSangName3()) ? null : request.getSangName3(), 
    			StringUtils.isEmpty(request.getReqRemark()) ? null : request.getReqRemark(), 
    			DateUtil.toDate(request.getAppDate(), DateUtil.PATTERN_YYMMDD), 
    			StringUtils.isEmpty(request.getAnswer()) ? null : request.getAnswer(),
    			StringUtils.isEmpty(request.getInOutGubun()) ? null : request.getInOutGubun(),
    			fkinp1001, 
    			StringUtils.isEmpty(request.getPrintYn()) ? null : request.getPrintYn(), 
    			StringUtils.isEmpty(request.getEmerGubun()) ? null : request.getEmerGubun(), 
    			DateUtil.toDate(request.getRealJinryoDate(), DateUtil.PATTERN_YYMMDD), 
    			DateUtil.toDate(request.getResultArriveDate(), DateUtil.PATTERN_YYMMDD), 
    			StringUtils.isEmpty(request.getConfirmYn()) ? null : request.getConfirmYn(), 
    			StringUtils.isEmpty(request.getAnswerEndYn()) ? null : request.getAnswerEndYn(), 
    			DateUtil.toDate(request.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD), 
    			StringUtils.isEmpty(request.getAmpmGubun()) ? null : request.getAmpmGubun(), 
    			StringUtils.isEmpty(request.getReqEndYn()) ? null : request.getReqEndYn(), 
    			StringUtils.isEmpty(request.getDisplayYn()) ? null : request.getDisplayYn(), 
    			StringUtils.isEmpty(request.getConsultSangName()) ? null : request.getConsultSangName(),
    			hospCode,
    			pkocs0503);
		if (result > 0){
    		return true;
		}
    	return false;
    }
    
    public boolean deleteOCS0503(OcsaOCS0503U01GrdOCS0503ListInfo request, String hospCode){
		Integer result = ocs0503Repository.deleteOCS0503U01(hospCode,CommonUtils.parseDouble(request.getPkocs0503()));
		if (result > 0){
			return true;
		}
    	return false;
    }
}
