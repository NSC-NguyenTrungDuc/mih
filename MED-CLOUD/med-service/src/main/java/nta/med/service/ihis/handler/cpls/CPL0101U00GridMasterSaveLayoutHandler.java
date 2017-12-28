package nta.med.service.ihis.handler.cpls;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.cpl.Cpl0101;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ModifyFlg;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00GridMasterSaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service
@Scope("prototype")
public class CPL0101U00GridMasterSaveLayoutHandler extends ScreenHandler<CplsServiceProto.CPL0101U00GridMasterSaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL0101U00GridMasterSaveLayoutHandler.class);
	@Resource
	private Cpl0101Repository cpl0101Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
		CPL0101U00GridMasterSaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = false;
		String hospitalCode = getHospitalCode(vertx, sessionId);
		List<CplsModelProto.CPL0101U00InitListItemInfo> listItem = request.getItemInfoList();
		if(!isValidKey(listItem, vertx, clientId, sessionId)){
    		response.setMsg("CPL0101_DUPLICATE_KEY");
    		response.setResult(false);
    		return response.build();
    	}
		
		for(CplsModelProto.CPL0101U00InitListItemInfo item : listItem){
			if(DataRowState.ADDED.getValue().equals(item.getDataRowState())){
				Cpl0101 cpl0101 = new Cpl0101();
				
				cpl0101.setSysDate(new Date());  
				cpl0101.setSysId(request.getUserId());  
				cpl0101.setUpdDate(new Date());
				cpl0101.setJukyongDate(DateUtil.toDate(item.getJukyongDate(),DateUtil.PATTERN_YYMMDD));  
				cpl0101.setHangmogCode(item.getHangmogCode());  
				cpl0101.setSpecimenCode(item.getSpecimenCode());  
				cpl0101.setEmergency(item.getEmergency());  
				cpl0101.setDefaultYn(item.getDefaultYn());  
				cpl0101.setJundalGubun(item.getJundalGubun());  
				cpl0101.setDanui(item.getDanui());  
				cpl0101.setTubeCode(item.getTubeCode());  
				cpl0101.setUitakCode(item.getUitakCode());  
				cpl0101.setSutakCode(item.getSutakCode());  
				cpl0101.setSlipCode(item.getSlipCode());  
				cpl0101.setJangbiCode(item.getJangbiCode());  
				cpl0101.setJangbiOutCode(item.getJangbiOutCode());  
				cpl0101.setJangbiCode2(item.getJangbiCode2());  
				cpl0101.setJangbiOutCode2(item.getJangbiOutCode2());  
				cpl0101.setJangbiCode3(item.getJangbiCode3());  
				cpl0101.setJangbiOutCode3(item.getJangbiOutCode3());  
				cpl0101.setGroupGubun(item.getGroupGubun());  
				cpl0101.setGumsaNameRe(item.getGumsaName());  
				cpl0101.setBarcode(item.getBarcode());  
				cpl0101.setGumsaName(item.getGumsaName());  
				cpl0101.setDefaultResult(item.getDefaultResult());  
				cpl0101.setMedicalJundal(item.getMedicalJundal());  
				cpl0101.setCommentJuCode(item.getCommentJuCode());  
				cpl0101.setSerial(CommonUtils.parseDouble(item.getSerial()));  
				cpl0101.setChubangYn(item.getChubangYn());  
				cpl0101.setResultYn(item.getResultYn());  
				cpl0101.setResultForm(item.getResultForm());  
				cpl0101.setTongGubun(item.getTongGubun());  
				cpl0101.setSpecimenAmt(CommonUtils.parseDouble(item.getSpecimenAmt()));  
				cpl0101.setOldSlipCode(item.getOldSlipCode());  
				cpl0101.setDetailInfo(item.getDetailInfo());  
				cpl0101.setDisplayYn(item.getDisplayYn());  
				cpl0101.setJundalGubunName(item.getJundalGubunName());  
				cpl0101.setSpcialName(item.getSpcialName());  
				cpl0101.setSystemGubun("CPL");  
				cpl0101.setTongSerial(CommonUtils.parseDouble(item.getTongSerial()));
				cpl0101.setPoint(CommonUtils.parseDouble(item.getPoint()));  
				cpl0101.setPoint2(CommonUtils.parseDouble(item.getPoint2()));  
				cpl0101.setPoint3(CommonUtils.parseDouble(item.getPoint3()));  
				cpl0101.setOutTube(item.getOutTube());  
				cpl0101.setOutTube2(item.getOutTube2());  
				cpl0101.setHangmogMarkName(item.getHangmogMarkName());  
				cpl0101.setMiddleResult(item.getMiddleResult());  
				cpl0101.setUserGubun(item.getUserGubun());  
				cpl0101.setHospCode(hospitalCode);  
				cpl0101.setModifyFlg(ModifyFlg.INSERT.getValue());
				cpl0101Repository.save(cpl0101);
				
				result = true;
			} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())){
				cpl0101Repository.updateCPL0101U000101(request.getUserId(), DateUtil.toDate(item.getJukyongDate(),DateUtil.PATTERN_YYMMDD),
						item.getSpecimenCode(), item.getEmergency(), item.getDefaultYn(), item.getJundalGubun(), item.getDanui(), item.getTubeCode(),
						item.getUitakCode(), item.getSutakCode(), item.getSlipCode(), item.getJangbiCode(), item.getJangbiOutCode(), item.getJangbiCode2(),
						item.getJangbiOutCode2(), item.getJangbiCode3(), item.getJangbiOutCode3(), item.getGroupGubun(), item.getGumsaNameRe(), 
						item.getBarcode(), item.getGumsaName(), item.getDefaultResult(), item.getMedicalJundal(), item.getCommentJuCode(), CommonUtils.parseDouble(item.getSerial()),
						item.getChubangYn(), item.getResultYn(), item.getResultForm(), item.getTongGubun(), CommonUtils.parseDouble(item.getSpecimenAmt()),
						item.getOldSlipCode(), item.getDetailInfo(), item.getDisplayYn(), item.getJundalGubunName(), item.getSpcialName(),
						CommonUtils.parseDouble(item.getTongSerial()), CommonUtils.parseDouble(item.getPoint()), CommonUtils.parseDouble(item.getPoint2()),
						CommonUtils.parseDouble(item.getPoint3()), item.getOutTube(), item.getOutTube2(), item.getHangmogMarkName(), item.getMiddleResult(),
						item.getUserGubun(), ModifyFlg.UPDATE.getValue(), hospitalCode, item.getHangmogCode());
				result = true;
			}else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())){
				cpl0101Repository.deleteCPL0101U00(hospitalCode, item.getHangmogCode());
				result = true;
			}
		}
		
		response.setResult(result);
		return response.build();
	}
	
	public boolean isValidKey(List<CplsModelProto.CPL0101U00InitListItemInfo> listItem, Vertx vertx, String clientId, String sessionId){
    	for (CplsModelProto.CPL0101U00InitListItemInfo info : listItem) {
            if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
                boolean existed = cpl0101Repository.isExistedCpl0101(getHospitalCode(vertx, sessionId), info.getHangmogCode(), info.getSpecimenCode(), info.getEmergency());
                if(existed){
                	LOGGER.info("CPL0101U00GridMasterSaveLayoutRequest: CPL0101_DUPLICATE_KEY: hospCode=" + getHospitalCode(vertx, sessionId)
                	+ ", hangmogCode=" + info.getHangmogCode() + ", specimenCode=" + info.getSpecimenCode() + ", emergency=" + info.getEmergency());
                	return false;
                }
            } 
    	}
    	return true;
    }
}
