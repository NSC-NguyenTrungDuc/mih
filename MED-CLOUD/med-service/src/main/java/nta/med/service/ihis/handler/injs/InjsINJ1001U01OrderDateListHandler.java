package nta.med.service.ihis.handler.injs;

import java.sql.Timestamp;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
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
public class InjsINJ1001U01OrderDateListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01OrderDateListRequest, InjsServiceProto.InjsINJ1001U01OrderDateListResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01OrderDateListHandler.class);
	@Resource
	private Inj1001Repository inj1001Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01OrderDateListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01OrderDateListRequest request) throws Exception {
		InjsServiceProto.InjsINJ1001U01OrderDateListResponse.Builder response = InjsServiceProto.InjsINJ1001U01OrderDateListResponse.newBuilder();
		List<Timestamp> listObject = inj1001Repository.getInjsINJ1001U01OrderDateList(getHospitalCode(vertx, sessionId), request.getPkinj1002());
        if(!CollectionUtils.isEmpty(listObject)) {
        	for(Timestamp item : listObject) {
        		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
        		if(item != null){
        			info.setDataValue(DateUtil.toString(item, DateUtil.PATTERN_YYMMDD));
        		}
        		response.addOrderDate(info);
        		//response.addOrderDate(item == null ? "" : DateUtil.toString(item, DateUtil.PATTERN_YYMMDD));
        	}
        }
		return response.build();
	}
}
