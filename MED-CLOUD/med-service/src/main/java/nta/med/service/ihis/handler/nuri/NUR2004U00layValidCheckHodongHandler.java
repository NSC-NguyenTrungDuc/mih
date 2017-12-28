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
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layValidCheckHodongRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layValidCheckHodongResponse;

@Service                                                                                                          
@Scope("prototype")
public class NUR2004U00layValidCheckHodongHandler extends ScreenHandler<NuriServiceProto.NUR2004U00layValidCheckHodongRequest, NuriServiceProto.NUR2004U00layValidCheckHodongResponse > {
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly=true)
	public NUR2004U00layValidCheckHodongResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00layValidCheckHodongRequest request) throws Exception {
		NuriServiceProto.NUR2004U00layValidCheckHodongResponse.Builder response = NuriServiceProto.NUR2004U00layValidCheckHodongResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String code = request.getCode();
		String date = request.getDate();
		
		List<DataStringListItemInfo> listInfo = bas0260Repository.getNUR2004U00layValidCheckHodong(hospCode, code, date);
		if(!CollectionUtils.isEmpty(listInfo)){
			for(DataStringListItemInfo item : listInfo){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(item.getItem());
				response.addGwaName(info);
			}
		}
		return response.build();
	}

}