package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017Q00xEditGridCell30Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017Q00xEditGridCell30Response;

@Service                                                                                                          
@Scope("prototype") 
public class NUR2017Q00xEditGridCell30Handler extends ScreenHandler<NuriServiceProto.NUR2017Q00xEditGridCell30Request, NuriServiceProto.NUR2017Q00xEditGridCell30Response>{
	@Resource
	private Ocs0132Repository ocs0132Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NUR2017Q00xEditGridCell30Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2017Q00xEditGridCell30Request request) throws Exception {
		NuriServiceProto.NUR2017Q00xEditGridCell30Response.Builder response = NuriServiceProto.NUR2017Q00xEditGridCell30Response.newBuilder();
		List<ComboListItemInfo> list = ocs0132Repository.getOCS0132ComboList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "JUSA_SPD_GUBUN");
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addXeditItem(info);
			}
		}
		return response.build();
	}

}
