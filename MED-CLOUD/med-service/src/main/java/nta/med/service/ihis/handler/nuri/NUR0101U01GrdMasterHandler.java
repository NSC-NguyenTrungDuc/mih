package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0101Repository;
import nta.med.data.model.ihis.nuri.NUR0101U01GrdMasterInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR0101U01GrdMasterHandler extends ScreenHandler<NuriServiceProto.NUR0101U01GrdMasterRequest, NuriServiceProto.NUR0101U01GrdMasterResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(NUR0101U01GrdMasterHandler.class);
	
	@Resource                                   
	private Nur0101Repository nur0101Repository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR0101U01GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR0101U01GrdMasterRequest request) throws Exception {
		NuriServiceProto.NUR0101U01GrdMasterResponse.Builder response = NuriServiceProto.NUR0101U01GrdMasterResponse.newBuilder(); 
		List<NUR0101U01GrdMasterInfo> listInfo = nur0101Repository.getNUR0101U01GrdMasterInfo(request.getCodeType(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listInfo)){
			for(NUR0101U01GrdMasterInfo info : listInfo){
				NuriModelProto.NUR0101U01GrdMasterInfo.Builder builder = NuriModelProto.NUR0101U01GrdMasterInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addGrdMasterInfo(builder);
			}
		}
		return response.build();
	}
}
