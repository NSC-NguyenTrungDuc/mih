package nta.med.service.ihis.handler.injs;

import java.math.BigInteger;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1001Repository;
import nta.med.data.model.ihis.injs.InjsINJ1001U01MasterListItemInfo;
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
public class InjsINJ1001U01MasterListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01MasterListRequest, InjsServiceProto.InjsINJ1001U01MasterListResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01MasterListHandler.class);
	@Resource
	private Inj1001Repository inj1001Repository;
	
	@Override
	public boolean isValid(InjsServiceProto.InjsINJ1001U01MasterListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getReserDate()) && DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01MasterListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01MasterListRequest request) throws Exception {
		List<InjsINJ1001U01MasterListItemInfo> listObject = inj1001Repository.getInjsINJ1001U01MasterListItemInfo(getHospitalCode(vertx, sessionId), request.getGwa(), request.getReserDate(), request.getActingFlag());
        InjsServiceProto.InjsINJ1001U01MasterListResponse.Builder response = InjsServiceProto.InjsINJ1001U01MasterListResponse.newBuilder();
        if (!CollectionUtils.isEmpty(listObject)) {
        	for (InjsINJ1001U01MasterListItemInfo item : listObject) {
        		InjsModelProto.InjsINJ1001U01MasterListItemInfo.Builder info = InjsModelProto.InjsINJ1001U01MasterListItemInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getReserGubun())) {
        			info.setReserGubun(item.getReserGubun());
        		}
        		if (!StringUtils.isEmpty(item.getBunho())) {
        			info.setBunho(item.getBunho());
        		}
        		if (!StringUtils.isEmpty(item.getSuname())) {
        			info.setSuname(item.getSuname());
        		}
        		if (!StringUtils.isEmpty(item.getOrderDate())) {
        			info.setOrderDate(item.getOrderDate());
        		}
        		if (!StringUtils.isEmpty(item.getReserDate())) {
        			info.setReserDate(item.getReserDate());
        		}
        		if (new BigInteger("1").compareTo(item.getNumProtocol()) <= 0) {
        			info.setTrialYn("Y");
        		} else {
        			info.setTrialYn("N");
        		}
        		response.addMasterListItem(info);
        	}
        }
		return response.build();
	}
}
