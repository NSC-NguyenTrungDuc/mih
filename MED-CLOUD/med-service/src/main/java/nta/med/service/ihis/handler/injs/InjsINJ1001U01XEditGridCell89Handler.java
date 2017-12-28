package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.injs.InjsINJ1001U01XEditGridCell89ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001U01XEditGridCell89Handler extends ScreenHandler<InjsServiceProto.INJ1001U01XEditGridCell89Request, InjsServiceProto.INJ1001U01XEditGridCell89Response>{
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001U01XEditGridCell89Handler.class);
	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01XEditGridCell89Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01XEditGridCell89Request request) throws Exception {
		InjsServiceProto.INJ1001U01XEditGridCell89Response.Builder response = InjsServiceProto.INJ1001U01XEditGridCell89Response.newBuilder();
		List<InjsINJ1001U01XEditGridCell89ItemInfo> xeditGridCell89List= nur0102Repository.getInjsINJ1001U01XEditGridCell89ItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(xeditGridCell89List)){
			for(InjsINJ1001U01XEditGridCell89ItemInfo item :xeditGridCell89List){
				InjsModelProto.INJ1001U01XEditGridCell89ItemInfo.Builder info =InjsModelProto.INJ1001U01XEditGridCell89ItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addXeditGridCell89Item(info);
			}
		}
		return response.build();
	}
}
