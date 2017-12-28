package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.model.ihis.invs.INV6002U00GrdINV6002Info;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV6002U00GrdINV6002Request;
import nta.med.service.ihis.proto.InvsServiceProto.INV6002U00GrdINV6002Response;

@Service
@Scope("prototype")
public class INV6002U00GrdINV6002Handler extends ScreenHandler<InvsServiceProto.INV6002U00GrdINV6002Request, InvsServiceProto.INV6002U00GrdINV6002Response>{

	@Resource
    private Inv0110Repository inv0110Repository;
	
	@Resource
    private Adm0000Repository adm0000Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INV6002U00GrdINV6002Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV6002U00GrdINV6002Request request) throws Exception {
		InvsServiceProto.INV6002U00GrdINV6002Response.Builder response = InvsServiceProto.INV6002U00GrdINV6002Response.newBuilder();
		String offset = request.getOffset();
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		String hangmogNameInx =  request.getJaeryoCode();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if(!StringUtils.isEmpty(hangmogNameInx) && Language.JAPANESE.toString().equalsIgnoreCase(language))
		{
			hangmogNameInx = adm0000Repository.callFnAdmConvertKanaFull(hospCode, hangmogNameInx);
		}
		List<INV6002U00GrdINV6002Info> grds = inv0110Repository.getINV6002U00GrdINV6002Info(hospCode, language,
			  request.getGubun(), request.getJaeryoGubun(), request.getMonth(), startNum, CommonUtils.parseInteger(offset), hangmogNameInx);
		if(!CollectionUtils.isEmpty(grds)){
			for (INV6002U00GrdINV6002Info item : grds) {
				InvsModelProto.INV6002U00GrdINV6002Info.Builder info = InvsModelProto.INV6002U00GrdINV6002Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdItem(info);
			}
		}
		
		return response.build();
	} 

}
