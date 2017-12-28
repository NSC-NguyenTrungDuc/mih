package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.GubunFlag;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00LayResultListTempListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00LayResultListTempRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00LayResultListTempResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0000Q00LayResultListTempHandler extends ScreenHandler<CplsServiceProto.CPL0000Q00LayResultListTempRequest, CplsServiceProto.CPL0000Q00LayResultListTempResponse> {
	private static final Log LOG = LogFactory.getLog(CPL0000Q00LayResultListTempHandler.class);
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public boolean isValid(CPL0000Q00LayResultListTempRequest request,
			Vertx vertx, String clientId, String sessionId) {
		if(!GubunFlag.ONE.getValue().equals(request.getGubunFlag()) && !GubunFlag.TWO.getValue().equals(request.getGubunFlag()) && !GubunFlag.THREE.getValue().equals(request.getGubunFlag())){
			return false;
		}
		
		return true;
	}
	
	@Override
	public CPL0000Q00LayResultListTempResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0000Q00LayResultListTempRequest request) throws Exception {
        CplsServiceProto.CPL0000Q00LayResultListTempResponse.Builder response = CplsServiceProto.CPL0000Q00LayResultListTempResponse.newBuilder();
        List<CPL0000Q00LayResultListTempListItemInfo> listItem = null;
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        if(GubunFlag.ONE.getValue().equals(request.getGubunFlag())){
        	listItem = cpl2010Repository.getCPL0000Q00LayResultListTemp1(hospitalCode, language, request.getBunho(),
        			request.getOrderDate(), request.getJundalGubun(), request.getGwa(), request.getDoctor());
        }else if(GubunFlag.TWO.getValue().equals(request.getGubunFlag())){
        	listItem = cpl2010Repository.getCPL0000Q00LayResultListTemp2(hospitalCode, language, request.getBunho(),
        			request.getResultDate(), request.getJundalGubun());
        }else if(GubunFlag.THREE.getValue().equals(request.getGubunFlag())){
        	listItem = cpl2010Repository.getCPL0000Q00LayResultListTemp3(hospitalCode, language, request.getBunho(),
        			request.getJubsuDate(), request.getJundalGubun());
        }
        
        if(!CollectionUtils.isEmpty(listItem)) {
        	for(CPL0000Q00LayResultListTempListItemInfo item : listItem) {
        		CplsModelProto.CPL0000Q00LayResultListTempListItemInfo.Builder info = CplsModelProto.CPL0000Q00LayResultListTempListItemInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getSortA())) {
        			info.setSortA(item.getSortA());
        		}
        		if (item.getSortB() != null) {
        			info.setSortB(item.getSortB().toString());
        		}
        		if (item.getSortC() != null) {
        			info.setSortC(item.getSortC().toString());
        		}
        		if (!StringUtils.isEmpty(item.getSortD())) {
        			info.setSortD(item.getSortD());
        		}
        		if (item.getFkcpl2010() != null) {
        			info.setFkcpl2010(item.getFkcpl2010().toString());
        		}
        		if (!StringUtils.isEmpty(item.getHangmogCode())) {
        			info.setHangmogCode(item.getHangmogCode());
        		}
        		if (!StringUtils.isEmpty(item.getSpecimenCode())) {
        			info.setSpecimenCode(item.getSpecimenCode());
        		}
        		if (!StringUtils.isEmpty(item.getSpecimenName())) {
        			info.setSpecimenName(item.getSpecimenName());
        		}
        		if (!StringUtils.isEmpty(item.getGumsaName())) {
        			info.setGumsaName(item.getGumsaName());
        		}
        		if (!StringUtils.isEmpty(item.getEmergency())) {
        			info.setEmergency(item.getEmergency());
        		}
        		if (!StringUtils.isEmpty(item.getSourceGumsa())) {
        			info.setSourceGumsa(item.getSourceGumsa());
        		}
        		if (!StringUtils.isEmpty(item.getCplResult())) {
        			info.setCplResult(item.getCplResult());
        		}
        		if (item.getResultDate() != null) {
        			info.setResultDate(DateUtil.toString(item.getResultDate(), DateUtil.PATTERN_YYMMDD));
        		}
        		if (!StringUtils.isEmpty(item.getResultTime())) {
        			info.setResultTime(item.getResultTime());
        		}
        		if (!StringUtils.isEmpty(item.getResultForm())) {
        			info.setResultForm(item.getResultForm());
        		}
        		if (item.getConfirmDate() != null) {
        			info.setConfirmDate(DateUtil.toString(item.getConfirmDate(), DateUtil.PATTERN_YYMMDD));
        		}
        		if (!StringUtils.isEmpty(item.getStandardYn())) {
        			info.setStandardYn(item.getStandardYn());
        		}
        		if (!StringUtils.isEmpty(item.getFromStandard())) {
        			info.setFromStandard(item.getFromStandard());
        		}
        		if (!StringUtils.isEmpty(item.getToStandard())) {
        			info.setToStandard(item.getToStandard());
        		}
        		if (!StringUtils.isEmpty(item.getStandard())) {
        			info.setStandard(item.getStandard());
        		}
        		if (!StringUtils.isEmpty(item.getPanicYn())) {
        			info.setPanicYn(item.getPanicYn());
        		}
        		if (!StringUtils.isEmpty(item.getDeltaYn())) {
        			info.setDeltaYn(item.getDeltaYn());
        		}
        		if (!StringUtils.isEmpty(item.getBeforeResult())) {
        			info.setBeforeResult(item.getBeforeResult());
        		}
        		if (!StringUtils.isEmpty(item.getDanui())) {
        			info.setDanui(item.getDanui());
        		}
        		if (!StringUtils.isEmpty(item.getDanuiName())) {
        			info.setDanuiName(item.getDanuiName());
        		}
        		if (!StringUtils.isEmpty(item.getBunho())) {
        			info.setBunho(item.getBunho());
        		}
        		if (!StringUtils.isEmpty(item.getGwa())) {
        			info.setGwa(item.getGwa());
        		}
        		if (!StringUtils.isEmpty(item.getDoctor())) {
        			info.setDoctor(item.getDoctor());
        		}
        		if (!StringUtils.isEmpty(item.getGubun())) {
        			info.setGubun(item.getGubun());
        		}
        		if (!StringUtils.isEmpty(item.getHoDong())) {
        			info.setHoDong(item.getHoDong());
        		}
        		if (!StringUtils.isEmpty(item.getHoCode())) {
        			info.setHoCode(item.getHoCode());
        		}
        		if (!StringUtils.isEmpty(item.getJundalGubun())) {
        			info.setJundalGubun(item.getJundalGubun());
        		}
        		if (!StringUtils.isEmpty(item.getSlipCode())) {
        			info.setSlipCode(item.getSlipCode());
        		}
        		if (!StringUtils.isEmpty(item.getSpecimenSer())) {
        			info.setSpecimenSer(item.getSpecimenSer());
        		}
        		if (item.getOrderDate() != null) {
        			info.setOrderDate(DateUtil.toString(item.getOrderDate(), DateUtil.PATTERN_YYMMDD));
        		}
        		if (!StringUtils.isEmpty(item.getOrderTime())) {
        			info.setOrderTime(item.getOrderTime());
        		}
        		if (item.getJubsuDate() != null) {
        			info.setJubsuDate(DateUtil.toString(item.getJubsuDate(), DateUtil.PATTERN_YYMMDD));
        		}
        		if (!StringUtils.isEmpty(item.getJubsuTime())) {
        			info.setJubsuTime(item.getJubsuTime());
        		}
        		if (item.getPartJubsuDate() != null) {
        			info.setPartJubsuDate(DateUtil.toString(item.getPartJubsuDate(), DateUtil.PATTERN_YYMMDD));
        		}
        		if (!StringUtils.isEmpty(item.getPartJubsuTime())) {
        			info.setPartJubsuTime(item.getPartJubsuTime());
        		}
        		if (!StringUtils.isEmpty(item.getModifyYn())) {
        			info.setModifyYn(item.getModifyYn());
        		}
        		if (!StringUtils.isEmpty(item.getModifyYn1())) {
        			info.setModifyYn1(item.getModifyYn1());
        		}
        		if (item.getPkcpl3020() != null) {
        			info.setPkcpl3020(item.getPkcpl3020().toString());
        		}
        		if (!StringUtils.isEmpty(item.getGwaName())) {
        			info.setGwaName(item.getGwaName());
        		}
        		if (!StringUtils.isEmpty(item.getDoctorName())) {
        			info.setDoctorName(item.getDoctorName());
        		}
        		if (!StringUtils.isEmpty(item.getGroupHangmog())) {
        			info.setGroupHangmog(item.getGroupHangmog());
        		}
        		if (!StringUtils.isEmpty(item.getPartJubsuja())) {
        			info.setPartJubsuja(item.getPartJubsuja());
        		}
        		if (!StringUtils.isEmpty(item.getGumsaja())) {
        			info.setGumsaja(item.getGumsaja());
        		}
        		if (!StringUtils.isEmpty(item.getSuname())) {
        			info.setSuname(item.getSuname());
        		}
        		if (item.getAge() != null) {
        			info.setAge(item.getAge().toString());
        		}
        		if (!StringUtils.isEmpty(item.getSex())) {
        			info.setSex(item.getSex());
        		}
        		if (!StringUtils.isEmpty(item.getFixNote())) {
        			info.setFixNote(item.getFixNote());
        		}
        		if (!StringUtils.isEmpty(item.getNote())) {
        			info.setNote(item.getNote());
        		}
        		if (!StringUtils.isEmpty(item.getJangbiCode())) {
        			info.setJangbiCode(item.getJangbiCode());
        		}
        		if (!StringUtils.isEmpty(item.getSrlCode())) {
        			info.setSrlCode(item.getSrlCode());
        		}
        		if (!StringUtils.isEmpty(item.getImageYn())) {
        			info.setImageYn(item.getImageYn());
        		}
        		if (item.getFkocs() != null) {
        			info.setFkocs(item.getFkocs().toString());
        		}
        		if (!StringUtils.isEmpty(item.getJundalGubunName())) {
        			info.setJundalGubunName(item.getJundalGubunName());
        		}
        		if (!StringUtils.isEmpty(item.getCommentsYn())) {
        			info.setCommentsYn(item.getCommentsYn());
        		}
        		
        		response.addLayResultList(info);
        	}
        }
        return response.build(); 
	}

}
