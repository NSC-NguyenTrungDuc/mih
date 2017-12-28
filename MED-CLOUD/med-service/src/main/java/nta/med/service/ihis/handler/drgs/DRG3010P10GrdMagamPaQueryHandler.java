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
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P10GrdMagamPaQueryInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMagamPaQueryRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10GrdMagamPaQueryResponse;

@Service
@Scope("prototype")
public class DRG3010P10GrdMagamPaQueryHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10GrdMagamPaQueryRequest, DrgsServiceProto.DRG3010P10GrdMagamPaQueryResponse> {
	
    @Resource
    private Drg3010Repository drg3010Repository;

    @Override
    @Transactional(readOnly = true)
    public DRG3010P10GrdMagamPaQueryResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DRG3010P10GrdMagamPaQueryRequest request) throws Exception {
    	
        DrgsServiceProto.DRG3010P10GrdMagamPaQueryResponse.Builder response = DrgsServiceProto.DRG3010P10GrdMagamPaQueryResponse.newBuilder();

        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        
        String fromDate = request.getFromDate();
        String toDate = request.getToDate();
        String hoDong = request.getHoDong();
        String bunho = request.getBunho();
        String magamGubun = request.getMagamGubun();
        String pageNumber = request.getPageNumber();
        String offset = request.getOffset();
        
        List<DRG3010P10GrdMagamPaQueryInfo> listInfo = drg3010Repository.getDRG3010P10GrdMagamPaQueryInfo(hospCode, fromDate, toDate, hoDong, bunho, magamGubun, pageNumber, offset);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10GrdMagamPaQueryInfo item : listInfo) {
                DrgsModelProto.DRG3010P10GrdMagamPaQueryInfo.Builder info = DrgsModelProto.DRG3010P10GrdMagamPaQueryInfo.newBuilder();
                BeanUtils.copyProperties(item, info, language);
                
                if(item.getMagamSer() != null){
                	info.setMagamSer(String.format("%.0f",item.getMagamSer()));
                }
                
                response.addGrdList(info);
            }
        }
        
        return response.build();
    }
}
