package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01DrgwonneaOWnCurListInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LoadChebangPrintInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LoadMakayJungboInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01WnSerialQryListItemInfo;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
public class DrgsDRG5100P01DsvOrderPrintHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01DsvOrderPrintRequest, DrgsServiceProto.DrgsDRG5100P01DsvOrderPrintResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01DsvOrderPrintHandler.class);

    @Resource
    private Drg2010Repository drg2010Repository;

    @Resource
    private Out1001Repository out1001Repository;

    @Resource
    private Out0101Repository out0101Repository;

    @Resource
    private Bas0001Repository bas0001Repository;
    
    @Override
    @Transactional
    public DrgsServiceProto.DrgsDRG5100P01DsvOrderPrintResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01DsvOrderPrintRequest request) throws Exception {
        DrgsServiceProto.DrgsDRG5100P01DsvOrderPrintResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01DsvOrderPrintResponse.newBuilder();
        Double drgBunho = CommonUtils.parseDouble(request.getDrgBunho());
        Date jubsuDate = DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD);
        
        //1.
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String fkocs1003 = drg2010Repository.getDrgsDRG5100P01MinFKOCS1003(hospitalCode, request.getJubsuDate(), drgBunho);
        if (!StringUtils.isEmpty(fkocs1003)) {
            Double fkOut1001 = CommonUtils.parseDouble(fkocs1003);
            //2.
            DrgsDRG5100P01LoadChebangPrintInfo loadChebangPrintItem = out1001Repository.getDrgsDRG5100P01LoadChebangPrintInfo(hospitalCode, fkOut1001);
            if (loadChebangPrintItem != null) {
                DrgsModelProto.DrgsDRG5100P01LoadChebangPrintInfo.Builder loadChebangPrintInfo = DrgsModelProto.DrgsDRG5100P01LoadChebangPrintInfo.newBuilder();
                BeanUtils.copyProperties(loadChebangPrintItem, loadChebangPrintInfo, getLanguage(vertx, sessionId));
                response.setChebangPrintItem(loadChebangPrintInfo);
            }
        }

        //3.
        String language = getLanguage(vertx, sessionId);
        DrgsDRG5100P01LoadMakayJungboInfo loadMakayJungboItem = out0101Repository.getDrgsDRG5100P01LoadMakayJungboInfo(hospitalCode, language,
                request.getIoGobun(), jubsuDate, drgBunho);
        if (loadMakayJungboItem != null) {
            DrgsModelProto.DrgsDRG5100P01LoadMakayJungboInfo.Builder loadMakayJungboInfo = DrgsModelProto.DrgsDRG5100P01LoadMakayJungboInfo.newBuilder();
            BeanUtils.copyProperties(loadMakayJungboItem, loadMakayJungboInfo, getLanguage(vertx, sessionId));
            response.setMakayJungbo(loadMakayJungboInfo);
        }

        //4.
        List<DrgsDRG5100P01DrgwonneaOWnCurListInfo> listDrgwonneaOWnCurItem = drg2010Repository.getDrgsDRG5100P01DrgwonneaOWnCurList(hospitalCode, language, request.getJubsuDate(), request.getDrgBunho());
        if (!CollectionUtils.isEmpty(listDrgwonneaOWnCurItem)) {
            for (DrgsDRG5100P01DrgwonneaOWnCurListInfo drgwonneaOWnCurItem : listDrgwonneaOWnCurItem) {
                DrgsModelProto.DrgsDRG5100P01DrgwonneaOWnCurListInfo.Builder drgwonneaOWnCurInfo = DrgsModelProto.DrgsDRG5100P01DrgwonneaOWnCurListInfo.newBuilder();
                BeanUtils.copyProperties(drgwonneaOWnCurItem, drgwonneaOWnCurInfo, getLanguage(vertx, sessionId));

                response.addDrgwonneaOwnCur(drgwonneaOWnCurInfo);
                //5.
                List<DrgsDRG5100P01WnSerialQryListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01WnSerialQryListItem(hospitalCode, language,
                        request.getJubsuDate(), request.getDrgBunho(), drgwonneaOWnCurItem.getSerialText());
                if (!CollectionUtils.isEmpty(listObject)) {
                    for (DrgsDRG5100P01WnSerialQryListItemInfo serialQryitem : listObject) {
                        DrgsModelProto.DrgsDRG5100P01WnSerialQryListItemInfo.Builder serialQryitemInfo = DrgsModelProto.DrgsDRG5100P01WnSerialQryListItemInfo.newBuilder();
                        BeanUtils.copyProperties(serialQryitem, serialQryitemInfo, getLanguage(vertx, sessionId));
                        serialQryitemInfo.setOSerialText(drgwonneaOWnCurItem.getSerialText());

                        response.addWnSerialItem(serialQryitemInfo);
                    }
                }

            }
        }
        
        //5.
        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(hospitalCode);
        if(!CollectionUtils.isEmpty(bas0001List)){
        	Bas0001 bas = bas0001List.get(0);
        	if(bas.getYoyangName() != null){
        		response.setHospName(bas.getYoyangName());
        	}
        	
        	if(bas.getJaedanName() != null){
        		response.setJaedanName(bas.getJaedanName());
        	}
        	
        	if(bas.getAddress1() != null){
        		response.setHospAddress1(bas.getAddress1());
        	}
        }
        
        return response.build();
    }
}
