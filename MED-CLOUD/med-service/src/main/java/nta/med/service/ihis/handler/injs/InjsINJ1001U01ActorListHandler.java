package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm3200;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001U01ActorListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01ActorListRequest, InjsServiceProto.InjsINJ1001U01ActorListResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01ActorListHandler.class);
	@Resource
	private Adm3200Repository adm3200Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01ActorListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01ActorListRequest request) throws Exception {
		InjsServiceProto.InjsINJ1001U01ActorListResponse.Builder response = InjsServiceProto.InjsINJ1001U01ActorListResponse.newBuilder();
		List<Adm3200> listObject = adm3200Repository.getInjsINJ1001U01ActorListItemInfo(getHospitalCode(vertx, sessionId));
        if(!CollectionUtils.isEmpty(listObject)) {
        	for(Adm3200 item : listObject) {
        		InjsModelProto.InjsINJ1001U01ActorListItemInfo.Builder info = InjsModelProto.InjsINJ1001U01ActorListItemInfo.newBuilder();
        		if(!StringUtils.isEmpty(item.getUserId())) {
        			info.setUserId(item.getUserId());
        		}
        		if(!StringUtils.isEmpty(item.getUserNm())) {
        			info.setUserNm(item.getUserNm());
        		}
        		if(!StringUtils.isEmpty(item.getDeptCode())) {
        			info.setDeptCode(item.getDeptCode());
        		}
        		response.addActorListItem(info);
        	}
        }
		return response.build();
	}
}
