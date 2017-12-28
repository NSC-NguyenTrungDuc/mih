package nta.med.service.ihis.handler.system.composite;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.system.FnDrgGetCycleOrdDateHandler;
import nta.med.service.ihis.handler.system.PrOcsConvertHangmogCodeHandler;
import nta.med.service.ihis.handler.system.PrOcsLoadHangmogInfoHandler;
import nta.med.service.ihis.proto.SystemServiceProto;

/**
 * @author dainguyen.
 */
@Service
@Scope("prototype")
public class LoadHangmogInfoCompositeFirstHandler extends ScreenHandler<SystemServiceProto.LoadHangmogInfoCompositeFirstRequest, SystemServiceProto.LoadHangmogInfoCompositeFirstResponse> {
	private static final Log LOGGER = LogFactory.getLog(LoadHangmogInfoCompositeFirstHandler.class);
    @Resource
    private FnDrgGetCycleOrdDateHandler fnDrgGetCycleOrdDateHandler;

    @Resource
    private PrOcsConvertHangmogCodeHandler prOcsConvertHangmogCodeHandler;

    @Resource
    private PrOcsLoadHangmogInfoHandler prOcsLoadHangmogInfoHandler;

    @Override
    @Transactional
    public SystemServiceProto.LoadHangmogInfoCompositeFirstResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, SystemServiceProto.LoadHangmogInfoCompositeFirstRequest request) throws Exception {
        SystemServiceProto.LoadHangmogInfoCompositeFirstResponse.Builder response = SystemServiceProto.LoadHangmogInfoCompositeFirstResponse.newBuilder();
        Map<Integer, String> mapConvertHangmog = new HashMap<Integer, String>();
        Integer mapKey = 0;
        if (request.hasDrgGetCycleOrdDate()) {
            response.setDrgGetCycleOrdDate(fnDrgGetCycleOrdDateHandler.handle(vertx, clientId, sessionId, contextId, request.getDrgGetCycleOrdDate()));
        }

        for (SystemServiceProto.PrOcsConvertHangmogCodeRequest item : request.getOcsConvertHangmogCodeList()) {
        	SystemServiceProto.PrOcsConvertHangmogCodeResponse hangmogCodeInfo = prOcsConvertHangmogCodeHandler.handle(vertx, clientId, sessionId, contextId, item);
            response.addOcsConvertHangmogCode(hangmogCodeInfo);
            if(hangmogCodeInfo != null){
            	mapConvertHangmog.put(mapKey, hangmogCodeInfo.getHangmogCode());
            }else{
            	mapConvertHangmog.put(mapKey, null);
            }
            mapKey = mapKey + 1;
            
        }
        List<SystemServiceProto.PrOcsLoadHangmogInfoRequest> loadHangMogBefores = request.getOcsLoadHangmogInfoList();
        LOGGER.info("LoadHangmogInfoCompositeFirstHandler PrOcsConvertHangmogCodeRequest Size : " + mapConvertHangmog.size());
        LOGGER.info("LoadHangmogInfoCompositeFirstHandler PrOcsLoadHangmogInfoRequest Size : " + loadHangMogBefores.size());
        Integer i = 0;
        if(mapConvertHangmog.size() == loadHangMogBefores.size()){
        	for (SystemServiceProto.PrOcsLoadHangmogInfoRequest item : loadHangMogBefores) {
        		if(!StringUtils.isEmpty(mapConvertHangmog.get(i)) && !mapConvertHangmog.get(i).equals(item.getHangmogCode())){
        			item = item.toBuilder()
        					.setHangmogCode(mapConvertHangmog.get(i))
        					.build();
        		}
                response.addOcsLoadHangmogInfo(prOcsLoadHangmogInfoHandler.handle(vertx, clientId, sessionId, contextId, item));
                i = i + 1;
            }
        }

        return response.build();
    }
}
