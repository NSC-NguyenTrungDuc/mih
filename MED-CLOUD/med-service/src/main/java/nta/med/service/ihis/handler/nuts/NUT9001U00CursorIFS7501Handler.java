package nta.med.service.ihis.handler.nuts;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ifs.Ifs7501;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ifs.Ifs7501Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00CursorIFS7501Request;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00CursorIFS7501Response;

@Service
@Scope("prototype")
public class NUT9001U00CursorIFS7501Handler extends
		ScreenHandler<NutsServiceProto.NUT9001U00CursorIFS7501Request, NutsServiceProto.NUT9001U00CursorIFS7501Response> {

	@Resource
	private Ifs7501Repository ifs7501Repository;

	@Override
	@Transactional(readOnly = true)
	public NUT9001U00CursorIFS7501Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUT9001U00CursorIFS7501Request request) throws Exception {

		NutsServiceProto.NUT9001U00CursorIFS7501Response.Builder response = NutsServiceProto.NUT9001U00CursorIFS7501Response.newBuilder();
		List<Ifs7501> listIfs7501 = ifs7501Repository.findByHospCodeFkNut2011(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPknut2011()));
		
		if(!CollectionUtils.isEmpty(listIfs7501)){
			for (Ifs7501 ifs7501 : listIfs7501) {
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(String.valueOf(ifs7501.getPkifs7501()));
				response.addDtItem(info);
			}
		}
		
		return response.build();
	}

}
