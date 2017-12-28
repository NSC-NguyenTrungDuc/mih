package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.inps.INP1003U00grdCSC0108Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdCSC0108Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00grdCSC0108Response;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00grdCSC0108Handler extends ScreenHandler<InpsServiceProto.INP1003U00grdCSC0108Request, InpsServiceProto.INP1003U00grdCSC0108Response> {

	@Resource
	private Bas0102Repository bas0102Repository;	
	
	@Override
	public INP1003U00grdCSC0108Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00grdCSC0108Request request) throws Exception {
		
		InpsServiceProto.INP1003U00grdCSC0108Response.Builder response = InpsServiceProto.INP1003U00grdCSC0108Response.newBuilder();
		
		String hospCode = request.getHospCode();
		String categoryGubun = request.getCategoryGubun();
		
		List<INP1003U00grdCSC0108Info> listInfo = bas0102Repository.getINP1003U00grdCSC0108(hospCode, categoryGubun);
		if (CollectionUtils.isEmpty(listInfo)) {
			return response.build();
		}
		
		for (INP1003U00grdCSC0108Info info : listInfo) {
			InpsModelProto.INP1003U00grdCSC0108Info.Builder infoProto = InpsModelProto.INP1003U00grdCSC0108Info.newBuilder();
			BeanUtils.copyProperties(info, infoProto, getLanguage(vertx, sessionId));
			response.addGrdMasterItem(infoProto);
		}
		
		return response.build();
	}

}
