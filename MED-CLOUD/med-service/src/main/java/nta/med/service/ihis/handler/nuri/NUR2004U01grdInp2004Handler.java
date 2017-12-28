package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.nuri.NUR2004U01grdInp2004Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01grdInp2004Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01grdInp2004Response;

@Service
@Scope("prototype")
public class NUR2004U01grdInp2004Handler extends
		ScreenHandler<NuriServiceProto.NUR2004U01grdInp2004Request, NuriServiceProto.NUR2004U01grdInp2004Response> {

	@Resource
	private Inp2004Repository inp2004Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR2004U01grdInp2004Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U01grdInp2004Request request) throws Exception {		
		
		NuriServiceProto.NUR2004U01grdInp2004Response.Builder response = NuriServiceProto.NUR2004U01grdInp2004Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<NUR2004U01grdInp2004Info> result = inp2004Repository.getNUR2004U01grdInp2004Info(hospCode, request.getHoDong(), request.getOrderDate());
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR2004U01grdInp2004Info item : result){
				NuriModelProto.NUR2004U01grdInp2004Info.Builder info = NuriModelProto.NUR2004U01grdInp2004Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
				
		return response.build();
	}

}
