package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.data.model.ihis.injs.INJ1002R01LayQueryListItemInfo;
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
public class INJ1002R01LayQuery2Handler extends ScreenHandler<InjsServiceProto.INJ1002R01LayQuery2Request, InjsServiceProto.INJ1002R01LayQueryResponse>{
	private static final Log LOG = LogFactory.getLog(INJ1002R01LayQuery2Handler.class);
	@Resource
	private Inj1002Repository inj1002Repository;
	
	@Override
	public boolean isValid(InjsServiceProto.INJ1002R01LayQuery2Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if(!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1002R01LayQueryResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1002R01LayQuery2Request request) throws Exception {
		InjsServiceProto.INJ1002R01LayQueryResponse.Builder response = InjsServiceProto.INJ1002R01LayQueryResponse.newBuilder();
		List<INJ1002R01LayQueryListItemInfo> listResult = inj1002Repository.INJ1002R01LayQuery2(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getFromDate(), request.getToDate());
        if (!CollectionUtils.isEmpty(listResult)) {
        	InjsModelProto.INJ1002R01LayQueryListItemInfo.Builder info = InjsModelProto.INJ1002R01LayQueryListItemInfo.newBuilder();
        	for (INJ1002R01LayQueryListItemInfo item : listResult) {
        		if (!StringUtils.isEmpty(item.getGwa())) {
        			info.setGwa(item.getGwa());
        		}
        		if (!StringUtils.isEmpty(item.getBuseoName())) {
        			info.setBuseoName(item.getBuseoName());
        		}
        		if (!StringUtils.isEmpty(item.getActingDate())) {
        			info.setActingDate(item.getActingDate());
        		}
        		if (!StringUtils.isEmpty(item.getHangmogCode())) {
        			info.setHangmogCode(item.getHangmogCode());
        		}
        		if (!StringUtils.isEmpty(item.getHangmogName())) {
        			info.setHangmogName(item.getHangmogName());
        		}
        		if (!StringUtils.isEmpty(item.getOrdDanui())) {
        			info.setOrdDanui(item.getOrdDanui());
        		}
        		if (item.getInwonCnt() != null) {
        			info.setInwonCnt(item.getInwonCnt().toString());
        		}
        		if (item.getSubulSuryang() != null) {
        			info.setSubulSuryang(item.getSubulSuryang().toString());
        		}
	            response.addLayQuerryList(info);
        	}
        }
		return response.build();
	}
}
