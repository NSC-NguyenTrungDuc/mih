package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00Grd4001GenImportCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class INV4001U00Grd4001GenImportCodeHandler extends ScreenHandler<InvsServiceProto.INV4001U00Grd4001GenImportCodeRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Inv0102Repository inv0102Repository;
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV4001U00Grd4001GenImportCodeRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
//		TODO remove INV4001U00Grd4001GenImportCodeHandler
		List<String> codeNames = inv0102Repository.getCodeNameByCodeAndCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "INV_IMPORT", "INV_PREFIX");
		if(!CollectionUtils.isEmpty(codeNames)){
			String churiSeq = commonRepository.getNextVal("CHURI_SEQ");
			response.setResult(codeNames.get(0).concat(churiSeq));
		}else{
			response.setResult("");
		}
		return response.build();
	}

}
