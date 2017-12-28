package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.data.model.ihis.injs.InjsINJ1001U01DetailListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001U01DetailListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01DetailListRequest, InjsServiceProto.InjsINJ1001U01DetailListResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01DetailListHandler.class);
	@Resource
	private Inj1002Repository inj1002Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01DetailListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01DetailListRequest request) throws Exception {
		 InjsServiceProto.InjsINJ1001U01DetailListResponse.Builder response = InjsServiceProto.InjsINJ1001U01DetailListResponse.newBuilder();
		 List<InjsINJ1001U01DetailListItemInfo> listObject = inj1002Repository.getInjsINJ1001U01DetailListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), 
         		request.getGwa(), request.getDoctor(), request.getReserDate(), request.getActingDate(), request.getActingFlag());
         if (!CollectionUtils.isEmpty(listObject)) {
         	for (InjsINJ1001U01DetailListItemInfo item : listObject){
         		InjsModelProto.InjsINJ1001U01DetailListItemInfo.Builder info = InjsModelProto.InjsINJ1001U01DetailListItemInfo.newBuilder();
         		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
         		info.setDv(String.format("%.0f", item.getDv()));            		
         		info.setFkinj1001(String.format("%.0f", item.getFkinj1001()));
         		info.setGroupSer(String.format("%.0f", item.getGroupSer()));
         		info.setPkinj1002(String.format("%.0f", item.getPkinj1002()));
         		info.setSunabSuryang(String.format("%.0f", item.getSunabSuryang()));
         		info.setSuryang(String.format("%.0f", item.getSuryang()));
         		info.setSeq(String.format("%.0f", item.getSeq()));
         		response.addDetailListItem(info);
         	}
         }
		return response.build();
	}
}
