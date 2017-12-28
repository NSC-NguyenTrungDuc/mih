package nta.med.service.ihis.handler.nuts;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nut.Nut0002Repository;
import nta.med.data.model.ihis.nuts.Nut0001U00GrdNut0002ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NutsModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUT0001U00Grd0002Handler extends ScreenHandler<NutsServiceProto.NUT0001U00Grd0002Request, NutsServiceProto.NUT0001U00Grd0002Response> {                     
	private static final Log LOGGER = LogFactory.getLog(NUT0001U00Grd0002Handler.class);                                    
	@Resource                                                                                                       
	private Nut0002Repository nut0002Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NutsServiceProto.NUT0001U00Grd0002Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NutsServiceProto.NUT0001U00Grd0002Request request) throws Exception {
		NutsServiceProto.NUT0001U00Grd0002Response.Builder response = NutsServiceProto.NUT0001U00Grd0002Response.newBuilder(); 
		List<Nut0001U00GrdNut0002ItemInfo> listGrdNut0002 = nut0002Repository.getNut0001U00GrdNut0002ItemInfo(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getFknut0001()));
		if(!CollectionUtils.isEmpty(listGrdNut0002)){
			for(Nut0001U00GrdNut0002ItemInfo item : listGrdNut0002){
				NutsModelProto.NUT0001U00GrdNUT0002ItemInfo.Builder info = NutsModelProto.NUT0001U00GrdNUT0002ItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrd002ItemInfo(info);
			}
		}
		return response.build();
	}                                                                                                                 
}