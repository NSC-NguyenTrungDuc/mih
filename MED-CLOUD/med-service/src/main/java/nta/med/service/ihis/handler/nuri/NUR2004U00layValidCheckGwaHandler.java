package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layValidCheckGwaRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layValidCheckGwaResponse;

@Service                                                                                                          
@Scope("prototype")
public class NUR2004U00layValidCheckGwaHandler extends ScreenHandler<NuriServiceProto.NUR2004U00layValidCheckGwaRequest, NuriServiceProto.NUR2004U00layValidCheckGwaResponse > {
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly=true)
	public NUR2004U00layValidCheckGwaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00layValidCheckGwaRequest request) throws Exception {
		NuriServiceProto.NUR2004U00layValidCheckGwaResponse.Builder response = NuriServiceProto.NUR2004U00layValidCheckGwaResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String code = request.getCode();
		String date = request.getDate();
		
		List<DataStringListItemInfo> listInfo = bas0260Repository.getNUR2004U00layValidCheckGwa(hospCode, code, date);
		if(!CollectionUtils.isEmpty(listInfo)){
			for(DataStringListItemInfo item : listInfo){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo
						.newBuilder().setDataValue(item.getItem());
				response.addGwaName(info);
			}
		}
		
		return response.build();
	}

}
