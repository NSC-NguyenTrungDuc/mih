package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL2010R00GetBarCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R00GetBarCodeRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R00GetBarCodeResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL2010R00GetBarCodeHandler extends ScreenHandler<CplsServiceProto.CPL2010R00GetBarCodeRequest, CplsServiceProto.CPL2010R00GetBarCodeResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL2010R00GetBarCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL2010R00GetBarCodeRequest request) throws Exception  {
        CplsServiceProto.CPL2010R00GetBarCodeResponse.Builder response = CplsServiceProto.CPL2010R00GetBarCodeResponse.newBuilder();
        List<CPL2010R00GetBarCodeInfo> listObject = cpl2010Repository.getCPL2010R00GetBarCodeInfo(getHospitalCode(vertx, sessionId),
        		getLanguage(vertx, sessionId), request.getSpecimenSer());
        if(!CollectionUtils.isEmpty(listObject)) {
        	for(CPL2010R00GetBarCodeInfo item : listObject) {
        		CplsModelProto.CPL2010R00GetBarCodeInfo.Builder info = CplsModelProto.CPL2010R00GetBarCodeInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getJundalGubun())) {
        			info.setJundalGubun(item.getJundalGubun());
        		}
        		if (!StringUtils.isEmpty(item.getJundalGubunName())) {
        			info.setJundalGubunName(item.getJundalGubunName());
        		}
        		if (!StringUtils.isEmpty(item.getSpecimenCode())) {
        			info.setSpecimenCode(item.getSpecimenCode());
        		}
        		if (!StringUtils.isEmpty(item.getSpecimenName())) {
        			info.setSpecimenName(item.getSpecimenName());
        		}
        		if (!StringUtils.isEmpty(item.getTubeCode())) {
        			info.setTubeCode(item.getTubeCode());
        		}
        		if (!StringUtils.isEmpty(item.getTubeName())) {
        			info.setTubeName(item.getTubeName());
        		}
        		if (!StringUtils.isEmpty(item.getInOutGubun())) {
        			info.setInOutGubun(item.getInOutGubun());
        		}
        		if (!StringUtils.isEmpty(item.getSpecimenSer())) {
        			info.setSpecimenSer(item.getSpecimenSer());
        		}
        		if (!StringUtils.isEmpty(item.getBunho())) {
        			info.setBunho(item.getBunho());
        		}
        		if (!StringUtils.isEmpty(item.getSuname())) {
        			info.setSuname(item.getSuname());
        		}
        		if (!StringUtils.isEmpty(item.getGwaName())) {
        			info.setGwaName(item.getGwaName());
        		}
        		if (!StringUtils.isEmpty(item.getDangerYn())) {
        			info.setDangerYn(item.getDangerYn());
        		}
        		if (!StringUtils.isEmpty(item.getSpecimenSerBa())) {
        			info.setSpecimenSerBa(item.getSpecimenSerBa());
        		}
        		if (!StringUtils.isEmpty(item.getJangbiCode())) {
        			info.setJangbiCode(item.getJangbiCode());
        		}
        		if (!StringUtils.isEmpty(item.getJangbiName())) {
        			info.setJangbiName(item.getJangbiName());
        		}
        		if (!StringUtils.isEmpty(item.getGumsaNameRe())) {
        			info.setGumsaNameRe(item.getGumsaNameRe());
        		}
        		if (!StringUtils.isEmpty(item.getTubeCount())) {
        			info.setTubeCount(item.getTubeCount());
        		}
        		if (!StringUtils.isEmpty(item.getTubeMaxAmt())) {
        			info.setTubeMaxAmt(item.getTubeMaxAmt());
        		}
        		if (!StringUtils.isEmpty(item.getTubeNumbering())) {
        			info.setTubeNumbering(item.getTubeNumbering());
        		}
        		response.addListItem(info);
        	}
        }
        return response.build();
	}
}
