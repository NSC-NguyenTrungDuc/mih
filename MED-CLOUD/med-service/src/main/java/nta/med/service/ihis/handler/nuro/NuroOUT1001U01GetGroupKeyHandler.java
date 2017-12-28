package nta.med.service.ihis.handler.nuro;


import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetGroupKeyInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroOUT1001U01GetGroupKeyHandler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01GetGroupKeyRequest, NuroServiceProto.NuroOUT1001U01GetGroupKeyResponse> {
		private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01GetGroupKeyHandler.class);
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01GetGroupKeyResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01GetGroupKeyRequest request) throws Exception {
		List<NuroOUT1001U01GetGroupKeyInfo> listNuroOUT1001U01GetGroupKeyInfo = bas0102Repository.getNuroOUT1001U01GetGroupKeyInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType(), request.getCode());
		NuroServiceProto.NuroOUT1001U01GetGroupKeyResponse.Builder response = NuroServiceProto.NuroOUT1001U01GetGroupKeyResponse.newBuilder();
		if(listNuroOUT1001U01GetGroupKeyInfo != null && !listNuroOUT1001U01GetGroupKeyInfo.isEmpty()){
			for(NuroOUT1001U01GetGroupKeyInfo item : listNuroOUT1001U01GetGroupKeyInfo){
				NuroModelProto.NuroOUT1001U01GetGroupKeyInfo.Builder nuroGetGroupKeyInfo = NuroModelProto.NuroOUT1001U01GetGroupKeyInfo.newBuilder();
				if(item.getGroupKey() != null){
					nuroGetGroupKeyInfo.setGroupKey(item.getGroupKey());
				}
				response.addGetGroupKeyItem(nuroGetGroupKeyInfo);
			}
		}
		return response.build();
	}
}
