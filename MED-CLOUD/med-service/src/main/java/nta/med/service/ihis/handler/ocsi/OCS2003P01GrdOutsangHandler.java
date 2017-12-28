package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocsa.OCS2003P01GrdOutsangInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01GrdOutsangRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01GrdOutsangResponse;

@Service
@Scope("prototype")
public class OCS2003P01GrdOutsangHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01GrdOutsangRequest, OcsiServiceProto.OCS2003P01GrdOutsangResponse>{
	@Resource
	private OutsangRepository outsangRepository;
		
	@Override
	@Transactional(readOnly=true)
	public OCS2003P01GrdOutsangResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01GrdOutsangRequest request) throws Exception {
		
		OcsiServiceProto.OCS2003P01GrdOutsangResponse.Builder response = OcsiServiceProto.OCS2003P01GrdOutsangResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String bunho = request.getBunho();
		String gwa = request.getGwa();
		String naewonDate = request.getNaewonDate();
		
		List<OCS2003P01GrdOutsangInfo> listInfo = outsangRepository.getOCS2003P01GrdOutsangInfo(hospCode, language, bunho, gwa, naewonDate);
		if(!CollectionUtils.isEmpty(listInfo)) {
			for(OCS2003P01GrdOutsangInfo item : listInfo){
				OcsiModelProto.OCS2003P01GrdOutsangInfo.Builder info = OcsiModelProto.OCS2003P01GrdOutsangInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdList(info);
			}
		}
		return response.build();
	}

}
