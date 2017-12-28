package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.injs.INJ1001U01GrdSangItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01DetailListItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01ScheduleItemInfo;
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
public class INJ1001U01GroupedHandler extends ScreenHandler<InjsServiceProto.INJ1001U01GroupedRequest, InjsServiceProto.INJ1001U01GroupedResponse> {
	private static final Log LOG = LogFactory.getLog(INJ1001U01GroupedHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Resource
	private Inj1002Repository inj1002Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01GroupedResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01GroupedRequest request) throws Exception {
		InjsServiceProto.INJ1001U01GroupedResponse.Builder response = InjsServiceProto.INJ1001U01GroupedResponse.newBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<INJ1001U01GrdSangItemInfo> listGrdSangItem = outsangRepository.getINJ1001U01GrdSangItemInfo(hospitalCode, request.getBunho(),request.getGwa(), request.getReserDate());
    	if (!CollectionUtils.isEmpty(listGrdSangItem)) {
            for (INJ1001U01GrdSangItemInfo item : listGrdSangItem) {
            	InjsModelProto.INJ1001U01GrdSangItemInfo.Builder info = InjsModelProto.INJ1001U01GrdSangItemInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            	response.addGrdSangItem(info);
            }
    	}
    	
    	List<InjsINJ1001U01ScheduleItemInfo> listScheduleItem = ocs1003Repository.getInjsINJ1001U01ScheduleItemInfo(hospitalCode, 
    			language, request.getBunho(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), 
        		request.getPostOrderYn(), request.getPreOrderYn(), DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD), request.getActingFlag());
    	if (!CollectionUtils.isEmpty(listScheduleItem)) {
        	for (InjsINJ1001U01ScheduleItemInfo item : listScheduleItem) {
        		InjsModelProto.InjsINJ1001U01ScheduleItemInfo.Builder info = InjsModelProto.InjsINJ1001U01ScheduleItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addScheduleItem(info);
        	}
        }
    	
    	List<InjsINJ1001U01DetailListItemInfo> listObject = inj1002Repository.getInjsINJ1001U01DetailListItemInfo(hospitalCode, language, request.getBunho(), 
        		request.getGwa(), request.getDoctor(), request.getReserDate(), request.getActingDate(), request.getActingFlag());
    	if (!CollectionUtils.isEmpty(listObject)) {
        	for (InjsINJ1001U01DetailListItemInfo item : listObject){
        		InjsModelProto.InjsINJ1001U01DetailListItemInfo.Builder info = InjsModelProto.InjsINJ1001U01DetailListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addDetailListItem(info);
        	}
        }
		return response.build();
	}
}
