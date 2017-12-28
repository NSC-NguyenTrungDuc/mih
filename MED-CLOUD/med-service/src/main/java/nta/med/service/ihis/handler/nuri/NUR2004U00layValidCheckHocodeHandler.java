package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.model.ihis.nuri.NUR2004U00layValidCheckHocodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layValidCheckHocodeRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layValidCheckHocodeResponse;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR2004U00layValidCheckHocodeHandler extends ScreenHandler<NuriServiceProto.NUR2004U00layValidCheckHocodeRequest, NuriServiceProto.NUR2004U00layValidCheckHocodeResponse> {
	@Resource
	private Bas0250Repository bas0250Repository;
	
	@Override
	@Transactional(readOnly=true)
	public NUR2004U00layValidCheckHocodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00layValidCheckHocodeRequest request) throws Exception {
		NuriServiceProto.NUR2004U00layValidCheckHocodeResponse.Builder response = NuriServiceProto.NUR2004U00layValidCheckHocodeResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String date = request.getDate();
		String code = request.getCode();
		String hoDong = request.getHodong();
		
		List<NUR2004U00layValidCheckHocodeInfo> listInfo = bas0250Repository.getNUR2004U00layValidCheckHocode(hospCode, hoDong, code, date);
		if(!CollectionUtils.isEmpty(listInfo)){
			for(NUR2004U00layValidCheckHocodeInfo item : listInfo){
				NuriModelProto.NUR2004U00layValidCheckHocodeInfo.Builder info = NuriModelProto.NUR2004U00layValidCheckHocodeInfo.newBuilder();
				BeanUtils.copyProperties(item, info,language);
				response.addListValidhocode(info);
			}
		}
		return response.build();
	}

}
