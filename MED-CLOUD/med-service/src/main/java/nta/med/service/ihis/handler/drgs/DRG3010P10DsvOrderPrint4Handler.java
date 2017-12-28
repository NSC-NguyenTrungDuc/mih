package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3011Repository;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint4Info;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvOrderPrint4Request;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvOrderPrint4Response;

@Service
@Scope("prototype")
public class DRG3010P10DsvOrderPrint4Handler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10DsvOrderPrint4Request, DrgsServiceProto.DRG3010P10DsvOrderPrint4Response> {
	
    @Resource
    private Drg3011Repository drg3011Repository;

    @Override
    @Transactional(readOnly = true)
    public DRG3010P10DsvOrderPrint4Response handle(Vertx vertx, String clientId, String sessionId, long contextId, DRG3010P10DsvOrderPrint4Request request) throws Exception {
    	
        DrgsServiceProto.DRG3010P10DsvOrderPrint4Response.Builder response = DrgsServiceProto.DRG3010P10DsvOrderPrint4Response.newBuilder();

        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
        String jubsuDate = request.getJubsuDate();
        String drgBunho = request.getDrgBunho();
        String serialText = request.getSerialText();
        
        List<DRG3010P10DsvOrderPrint4Info> listInfo = drg3011Repository.getDRG3010P10DsvOrderPrint4Info(hospCode, language, jubsuDate, drgBunho, serialText);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10DsvOrderPrint4Info item : listInfo) {
                DrgsModelProto.DRG3010P10DsvOrderPrint4Info.Builder info = DrgsModelProto.DRG3010P10DsvOrderPrint4Info.newBuilder();
                BeanUtils.copyProperties(item, info, language);
                
                if (item.getDrgBunho() != null) {
    				info.setDrgBunho(String.format("%.0f",item.getDrgBunho()));
    			}
    			
    			if (item.getGroupSer() != null) {
    				info.setGroupSer(String.format("%.0f",item.getGroupSer()));
    			}
    			
    			if (item.getNalsu() != null) {
    				info.setNalsu(String.format("%.0f",item.getNalsu()));
    			}
    			
    			if (item.getOrdSuryang() != null) {
    				info.setOrdSuryang(String.format("%.0f",item.getOrdSuryang()));
    			}
    			
    			if (item.getOrderSuryang() != null) {
    				info.setOrderSuryang(String.format("%.0f",item.getOrderSuryang()));
    			}
    			
    			if (item.getDv() != null) {
    				info.setDv(String.format("%.0f",item.getDv()));
    			}
    			
    			if (item.getFkocs2003() != null) {
    				info.setFkocs2003(String.format("%.0f",item.getFkocs2003()));
    			}
    			
    			if (item.getSubulSuryang() != null) {
    				info.setSubulSuryang(String.format("%.0f",item.getSubulSuryang()));
    			}
                
                response.addTblList(info);
            }
        }
        return response.build();
    }

}
