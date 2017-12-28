package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01ChangeGubunLayGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class INP1001U01ChangeGubunLayGubunHandler
		extends ScreenHandler<InpsServiceProto.INP1001U01ChangeGubunLayGubunRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01ChangeGubunLayGubunRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String bunho = request.getBunho();
		String gubun = request.getGubun();
		Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		
		List<ComboListItemInfo> lstInfo = inp1001Repository.getComboChangeGubunInp1001U01(hospCode, language, bunho, gubun, naewonDate);
		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (ComboListItemInfo info : lstInfo) {
			CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(info.getCode()).setCodeName(info.getCodeName());
			
			response.addComboItem(protoInfo);
		}
		
		return response.build();
	}

}
