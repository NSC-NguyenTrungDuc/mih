package nta.med.service.ihis.handler.bill;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bill.Bil0001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bil.Bil0001Repository;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
@Transactional
public class BIL2016U00SaveGrdMasterHandler extends ScreenHandler<BillServiceProto.BIL2016U00SaveGrdMasterRequest, SystemServiceProto.UpdateResponse> {

    private static final Log LOGGER = LogFactory.getLog(BIL2016U00SaveGrdMasterHandler.class);

    @Resource
    private Bil0001Repository bil0001Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
                                                    BillServiceProto.BIL2016U00SaveGrdMasterRequest request) throws Exception {

        String userId = getUserId(vertx, sessionId);
        String hospCode = getHospitalCode(vertx, sessionId);
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        response.setResult(true);
        
        try {
        	List<BillModelProto.BIL2016U00DetailServiceInfo> infoList = request.getInfoList();
        	for (BillModelProto.BIL2016U00DetailServiceInfo info : infoList) {
        		List<Bil0001> bil0001s = bil0001Repository.findByHospCodeAndHangmogCode(hospCode, info.getHangmogCode());
        		if(CollectionUtils.isEmpty(bil0001s)){
        			insertBil0001(hospCode, userId, info);
        		} else {
        			Bil0001 bil0001 = bil0001s.get(0);
        	        bil0001.setPrice1(!StringUtils.isEmpty(info.getInsurancePrice()) ? new BigDecimal(info.getInsurancePrice()) : null);
        	        bil0001.setPrice2(!StringUtils.isEmpty(info.getServicePrice()) ? new BigDecimal(info.getServicePrice()) : null);
        	        bil0001.setPrice3(!StringUtils.isEmpty(info.getForeignerPrice()) ? new BigDecimal(info.getForeignerPrice()) : null);
        	        bil0001.setUpdated(new Date());
        	        
        	        bil0001Repository.save(bil0001);
        		}
			}
        	
        } catch (Exception e) {
            LOGGER.info("BIL2016U00SaveGrdMasterHandler Exception", e);
            response.setResult(false);
            throw new ExecutionException(response.build());
        }
        
        return response.build();
    }

    private Bil0001 insertBil0001(String hospCode, String userId, BillModelProto.BIL2016U00DetailServiceInfo info){
    	Bil0001 bil0001 = new Bil0001();
        bil0001.setHangmogCode(info.getHangmogCode());
        bil0001.setPrice1(!StringUtils.isEmpty(info.getInsurancePrice()) ? new BigDecimal(info.getInsurancePrice()) : null);
        bil0001.setPrice2(!StringUtils.isEmpty(info.getServicePrice()) ? new BigDecimal(info.getServicePrice()) : null);
        bil0001.setPrice3(!StringUtils.isEmpty(info.getForeignerPrice()) ? new BigDecimal(info.getForeignerPrice()) : null);
        bil0001.setActiveFlg(BigDecimal.ONE);
        bil0001.setUpdId(userId);
        bil0001.setSysId(userId);
        bil0001.setHospCode(hospCode);
        bil0001.setCreated(new Date());
        bil0001.setUpdated(new Date());
        
        bil0001Repository.save(bil0001);
        return bil0001;
    }
    
}
