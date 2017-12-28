package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.nuri.NUR0101U01GrdDetailInfo;
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
public class NUR0101U01GrdDetailHandler extends ScreenHandler<NuriServiceProto.NUR0101U01GrdDetailRequest, NuriServiceProto.NUR0101U01GrdDetailResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(NUR0101U01GrdDetailHandler.class);
	
	@Resource                                   
	private Nur0102Repository nur0102Repository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR0101U01GrdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR0101U01GrdDetailRequest request) throws Exception {
		NuriServiceProto.NUR0101U01GrdDetailResponse.Builder response = NuriServiceProto.NUR0101U01GrdDetailResponse.newBuilder(); 
		List<NUR0101U01GrdDetailInfo> listInfo = nur0102Repository.getNUR0101U01GrdDetailInfo(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listInfo)){
			for(NUR0101U01GrdDetailInfo info : listInfo){
				NuriModelProto.NUR0101U01GrdDetailInfo.Builder builder = NuriModelProto.NUR0101U01GrdDetailInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addGrdDetailInfo(builder);
			}
		}
		return response.build();
	}
}
