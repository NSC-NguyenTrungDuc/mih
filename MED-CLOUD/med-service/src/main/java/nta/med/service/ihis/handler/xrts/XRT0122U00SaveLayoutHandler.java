package nta.med.service.ihis.handler.xrts;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.xrt.Xrt0121;
import nta.med.core.domain.xrt.Xrt0122;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.xrt.Xrt0121Repository;
import nta.med.data.dao.medi.xrt.Xrt0122Repository;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.XrtsModelProto.XRT0122U00SaveLayoutInfo;
import nta.med.service.ihis.proto.XrtsServiceProto;

@Service
@Scope("prototype")
@Transactional
public class XRT0122U00SaveLayoutHandler extends ScreenHandler<XrtsServiceProto.XRT0122U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0122U00SaveLayoutHandler.class);
    @Resource
    private Xrt0121Repository xrt0121Repository;
    @Resource
    private Xrt0122Repository xrt0122Repository;

    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0122U00SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Integer result = null;
        try
        {
            String hospitalCode = getHospitalCode(vertx, sessionId);
            for (XRT0122U00SaveLayoutInfo info : request.getSaveLayoutItemList()) {
                if (info.getCallerId().equalsIgnoreCase("1")) {
                    if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                        if (!StringUtils.isEmpty(info.getBuwiBunryu())) {
                            result = insertXrt0121(info, request.getUserId(), hospitalCode, getLanguage(vertx, sessionId));
                        } else {
                            response.setResult(false);
                            throw new ExecutionException(response.build());
                        }
                    } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                        result = xrt0121Repository.updateXrt0121Transaction(request.getUserId(), info.getBuwiBunryuName(), hospitalCode, info.getBuwiBunryu(), getLanguage(vertx, sessionId));
                    } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                        result = xrt0121Repository.deleteXrt0121Transaction(hospitalCode, info.getBuwiBunryu(), getLanguage(vertx, sessionId));
                    }
                }
            }
        }
        catch (Exception e)
        {
            response.setResult(false);
            throw new ExecutionException(response.build());
        }

        response.setResult(result != null && result > 0);
    	return response.build();
    }
    
    public Integer insertXrt0121(XRT0122U00SaveLayoutInfo info, String userId, String hospitalCode, String language) {
        Xrt0121 xrt0121 = new Xrt0121();
        xrt0121.setSysDate(new Date());
        xrt0121.setSysId(userId);
        xrt0121.setUpdDate(new Date());
        xrt0121.setUpdId(userId);
//        xrt0121.setHospCode(hospitalCode);
        xrt0121.setBuwiBunryu(!StringUtils.isEmpty(info.getBuwiBunryu()) ? info.getBuwiBunryu() : null);
        xrt0121.setBuwiBunryuName(!StringUtils.isEmpty(info.getBuwiBunryuName()) ? info.getBuwiBunryuName() : null);
        xrt0121.setLanguage(language);
        xrt0121Repository.save(xrt0121);
        return 1;
    }

    public Integer insertXrt0122(XRT0122U00SaveLayoutInfo info, String userId, String hospitalCode, String language) {
        try {
            Xrt0122 xrt0122 = new Xrt0122();
            xrt0122.setSysDate(new Date());
            xrt0122.setSysId(userId);
            xrt0122.setUpdDate(new Date());
            xrt0122.setUpdId(userId);
            xrt0122.setBuwiBunryu(info.getBuwiBunryu());
            xrt0122.setBuwiCode(info.getBuwiCode());
            xrt0122.setBuwiName(info.getBuwiName());
            xrt0122.setHospCode(hospitalCode);
            if (!StringUtils.isEmpty(info.getSortSeq())) {
                xrt0122.setSortSeq(CommonUtils.parseDouble(info.getSortSeq()));
            } else {
                xrt0122.setSortSeq(new Double(0));
            }
            xrt0122.setLanguage(language);
            xrt0122Repository.save(xrt0122);
            return 1;
        } catch (Exception e) {
            LOGGER.error("Error on insertXrt0122 " + e.getMessage(), e);
            throw new ExecutionException(e.getMessage(), e);
        }

    }
    
    
    @Override
    @Route(global = false)
    public SystemServiceProto.UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		XrtsServiceProto.XRT0122U00SaveLayoutRequest request, SystemServiceProto.UpdateResponse rs) throws Exception {
    	SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
    	Integer result = null;
    	 try
         {
             String hospitalCode = getHospitalCode(vertx, sessionId);
             String language = getLanguage(vertx, sessionId);
             for (XRT0122U00SaveLayoutInfo info : request.getSaveLayoutItemList()) {
                 if (info.getCallerId().equalsIgnoreCase("1")) {
                     if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                         String checkYn = "N";
                         List<String> list = xrt0122Repository.getXrt0121Loop(hospitalCode, info.getBuwiBunryu(), language);
                         if (!CollectionUtils.isEmpty(list)) {
                             checkYn = "Y";
                         }
                         if (checkYn.equals("Y")) {
                             result = xrt0122Repository.deleteXrt0121TransactionXrt0122(hospitalCode, info.getBuwiBunryu(), language);
                         }
                     }
                 } else if (info.getCallerId().equalsIgnoreCase("2")) {
                     if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                         result = insertXrt0122(info, request.getUserId(), hospitalCode, language);
                     } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                         result = xrt0122Repository.updateXrt0121TransactionXrt0122(request.getUserId(), info.getBuwiName(), info.getSortSeq(), hospitalCode,
                                 info.getBuwiBunryu(), info.getBuwiCode(), language);
                     } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                         result = xrt0122Repository.deleteXrt0121TransactionXrt0122Case2(hospitalCode, info.getBuwiBunryu(), info.getBuwiCode(), language);
                     }
                 }
             }
         }
         catch (Exception e)
         {
             response.setResult(false);
             throw new ExecutionException(response.build());
         }

         response.setResult(result != null && result > 0);
         return response.build();
     }
}