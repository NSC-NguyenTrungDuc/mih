package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.cpl.Cpl0101;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ModifyFlg;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00TransactionalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL0101U00TransactionalHandler extends ScreenHandler<CplsServiceProto.CPL0101U00TransactionalRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL0101U00TransactionalHandler.class);
	@Resource
	private Cpl0101Repository cpl0101Repository;
	
	@Override
	public boolean isValid(CPL0101U00TransactionalRequest request, Vertx vertx,
			String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getJukyongDate())&& DateUtil.toDate(request.getJukyongDate(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL0101U00TransactionalRequest request) throws Exception {
		String hospitalCode = getHospitalCode(vertx, sessionId);
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = false;
		if(DataRowState.ADDED.getValue().equals(request.getRowState())){
			result = insertCPL0101U00(request, hospitalCode);
		} else if(DataRowState.MODIFIED.getValue().equals(request.getRowState())){
			result = updateCPl0101U00(request, hospitalCode);
		}else if(DataRowState.DELETED.getValue().equals(request.getRowState())){
			result = deleteCPL0101U00(request, hospitalCode);
		}
		response.setResult(result);
		return response.build();
	}
	
	public boolean insertCPL0101U00(CplsServiceProto.CPL0101U00TransactionalRequest request, String hospitalCode){
		try {
			Cpl0101 cpl0101 = new Cpl0101();
			
			cpl0101.setSysDate(new Date());  
			cpl0101.setSysId(request.getUserId());  
			cpl0101.setUpdDate(new Date());
			cpl0101.setJukyongDate(DateUtil.toDate(request.getJukyongDate(),DateUtil.PATTERN_YYMMDD));  
			cpl0101.setHangmogCode(request.getHangmogCode());  
			cpl0101.setSpecimenCode(request.getSpecimenCode());  
			cpl0101.setEmergency(request.getEmergency());  
			cpl0101.setDefaultYn(request.getDefaultYn());  
			cpl0101.setJundalGubun(request.getJundalGubun());  
			cpl0101.setDanui(request.getDanui());  
			cpl0101.setTubeCode(request.getTubeCode());  
			cpl0101.setUitakCode(request.getUitakCode());  
			cpl0101.setSutakCode(request.getSutakCode());  
			cpl0101.setSlipCode(request.getSlipCode());  
			cpl0101.setJangbiCode(request.getJangbiCode());  
			cpl0101.setJangbiOutCode(request.getJangbiOutCode());  
			cpl0101.setJangbiCode2(request.getJangbiCode2());  
			cpl0101.setJangbiOutCode2(request.getJangbiOutCode2());  
			cpl0101.setJangbiCode3(request.getJangbiCode3());  
			cpl0101.setJangbiOutCode3(request.getJangbiOutCode3());  
			cpl0101.setGroupGubun(request.getGroupGubun());  
			cpl0101.setGumsaNameRe(request.getGumsaName());  
			cpl0101.setBarcode(request.getBarcode());  
			cpl0101.setGumsaName(request.getGumsaName());  
			cpl0101.setDefaultResult(request.getDefaultResult());  
			cpl0101.setMedicalJundal(request.getMedicalJundal());  
			cpl0101.setCommentJuCode(request.getCommentJuCode());  
			if(request.getSerial() != null && !request.getSerial().isEmpty()){
			cpl0101.setSerial(CommonUtils.parseDouble(request.getSerial()));  
			}
			cpl0101.setChubangYn(request.getChubangYn());  
			cpl0101.setResultYn(request.getResultForm());  
			cpl0101.setResultForm(request.getResultForm());  
			cpl0101.setTongGubun(request.getTongGubun());  
			if(request.getSpecimenAmt() != null && !request.getSpecimenAmt().isEmpty()){
			cpl0101.setSpecimenAmt(CommonUtils.parseDouble(request.getSpecimenAmt()));  
			}
			cpl0101.setOldSlipCode(request.getOldSlipCode());  
			cpl0101.setDetailInfo(request.getDetailInfo());  
			cpl0101.setDisplayYn(request.getDisplayYn());  
			cpl0101.setJundalGubunName(request.getJundalGubunName());  
			cpl0101.setSpcialName(request.getSpcialName());  
			cpl0101.setSystemGubun(request.getSystemGubun());  
			if(request.getTongSerial() != null && !request.getTongSerial().isEmpty()){
			cpl0101.setTongSerial(CommonUtils.parseDouble(request.getTongSerial()));  
			}
			if(request.getPoint() != null && !request.getPoint().isEmpty()){
			cpl0101.setPoint(CommonUtils.parseDouble(request.getPoint()));  
			}
			if(request.getPoint2() != null && !request.getPoint2().isEmpty()){
			cpl0101.setPoint2(CommonUtils.parseDouble(request.getPoint2()));  
			}
			if(request.getPoint3() != null && !request.getPoint3().isEmpty()){
			cpl0101.setPoint3(CommonUtils.parseDouble(request.getPoint3()));  
			}
			cpl0101.setOutTube(request.getOutTube());  
			cpl0101.setOutTube2(request.getOutTube2());  
			cpl0101.setHangmogMarkName(request.getHangmogMarkName());  
			cpl0101.setMiddleResult(request.getMiddleResult());  
			cpl0101.setUserGubun(request.getUserGubun());  
			cpl0101.setHospCode(hospitalCode);  
			cpl0101.setModifyFlg(ModifyFlg.INSERT.getValue());
			cpl0101Repository.save(cpl0101);
			return true;
		} catch (Exception e) {
			LOGGER.error(e.getMessage(),e);
			return false;
		}
	}
	
	public boolean updateCPl0101U00(CplsServiceProto.CPL0101U00TransactionalRequest request, String hospitalCode){
		try {
			if(cpl0101Repository.updateCPL0101U000101(
					request.getUserId(), 
					DateUtil.toDate(request.getJukyongDate(),DateUtil.PATTERN_YYMMDD), 
					request.getSpecimenCode(), 
					request.getEmergency(), 
					request.getDefaultYn(), 
					request.getJundalGubun(), 
					request.getDanui(), 
					request.getTubeCode(), 
					request.getUitakCode(), 
					request.getSutakCode(), 
					request.getSlipCode(), 
					request.getJangbiCode(), 
					request.getJangbiOutCode(), 
					request.getJangbiCode2(), 
					request.getJangbiOutCode2(), 
					request.getJangbiCode3(), 
					request.getJangbiOutCode3(), 
					request.getGroupGubun(), 
					request.getGumsaNameRe(), 
					request.getBarcode(), 
					request.getGumsaName(), 
					request.getDefaultResult(), 
					request.getMedicalJundal(), 
					request.getCommentJuCode(), 
					CommonUtils.parseDouble(request.getSerial()), 
					request.getChubangYn(), 
					request.getResultYn(), 
					request.getResultForm(), 
					request.getTongGubun(), 
					CommonUtils.parseDouble(request.getSpecimenAmt()), 
					request.getOldSlipCode(), 
					request.getDetailInfo(), 
					request.getDisplayYn(), 
					request.getJundalGubunName(), 
					request.getSpcialName(),
					CommonUtils.parseDouble(request.getTongSerial()),
					CommonUtils.parseDouble(request.getPoint()),
					CommonUtils.parseDouble(request.getPoint2()),
					CommonUtils.parseDouble(request.getPoint3()),
					request.getOutTube(), 
					request.getOutTube2(), 
					request.getHangmogMarkName(), 
					request.getMiddleResult(), 
					request.getUserGubun(), ModifyFlg.UPDATE.getValue(),
					hospitalCode, 
					request.getHangmogCode())>0)
			return true;
		} catch (Exception e) {
			LOGGER.error(e.getMessage(),e);
			return false;
		}
		return false;
	}
	public boolean deleteCPL0101U00(CplsServiceProto.CPL0101U00TransactionalRequest request, String hospitalCode){
		try {
			if(cpl0101Repository.deleteCPL0101U00(hospitalCode, request.getHangmogCode())>0)
				return true;
		} catch (Exception e) {
			LOGGER.error(e.getMessage(),e);
			return false;
		}
		return false;
	}
}
