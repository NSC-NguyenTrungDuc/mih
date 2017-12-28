package nta.med.service.emr.handler;

import java.util.Arrays;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.Adm3200;
import nta.med.core.glossary.EmrTemplateClassify;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrTemplateRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.emr.OCS2015U31GetEmrTemplateInfo;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31GetEmrTemplateRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31GetEmrTemplateResponse;

/**
 * @author DEV_HieuTT
 *
 */
@Service
@Scope("prototype")
public class OCS2015U31GetEmrTemplateHandler extends ScreenHandler<OCS2015U31GetEmrTemplateRequest, OCS2015U31GetEmrTemplateResponse> {
	
	@Resource
	private EmrTemplateRepository emrTemplateRepository;
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2015U31GetEmrTemplateResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS2015U31GetEmrTemplateRequest request) throws Exception {
		
		EmrServiceProto.OCS2015U31GetEmrTemplateResponse.Builder response = EmrServiceProto.OCS2015U31GetEmrTemplateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<Adm3200> adms = adm3200Repository.findByHospCodeUserId(hospCode, getUserId(vertx, sessionId));
		if(CollectionUtils.isEmpty(adms)){
			return response.build();
		}
		
		boolean isAdmin = "ADMIN".equals(adms.get(0).getUserGroup()) || "SAM".equals(adms.get(0).getUserGroup());
		boolean isCommonTab = "Y".equals(request.getCommonYn());
		
		List<String> depts = isAdmin ? Arrays.asList(request.getDepartCode()) : bas0270Repository.getGwaBySabunAndHospCode(hospCode, getUserId(vertx, sessionId));
		String doctorCode = isAdmin ? request.getDoctorCode() : getUserId(vertx, sessionId);
		String type = isAdmin ? request.getType() : (isCommonTab ? "" : EmrTemplateClassify.USER.getValue());
		String permissionType = isAdmin || isCommonTab ? "S" : "";
		
		List<OCS2015U31GetEmrTemplateInfo> listResult = emrTemplateRepository.getOCS2015U31GetEmrTemplateListInfo(hospCode, request.getUserId(), "", permissionType, type, depts, doctorCode, isCommonTab, language);
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS2015U31GetEmrTemplateInfo item : listResult){
				EmrModelProto.OCS2015U31GetEmrTemplateInfo.Builder info = EmrModelProto.OCS2015U31GetEmrTemplateInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGridTemplateItemInfo(info);
			}
		}
		
		return response.build();
	}
}
