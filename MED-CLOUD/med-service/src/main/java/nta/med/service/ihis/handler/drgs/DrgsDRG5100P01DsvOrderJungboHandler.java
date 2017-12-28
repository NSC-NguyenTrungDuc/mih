package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01JungboListInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01OrderJungboListItemInfo;
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

@Service
@Scope("prototype")
public class DrgsDRG5100P01DsvOrderJungboHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01DsvOrderJungboRequest, DrgsServiceProto.DrgsDRG5100P01DsvOrderJungboResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01DsvOrderJungboHandler.class);

    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01DsvOrderJungboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01DsvOrderJungboRequest request) throws Exception {
        DrgsServiceProto.DrgsDRG5100P01DsvOrderJungboResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01DsvOrderJungboResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        List<DrgsDRG5100P01OrderJungboListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01OrderJungboListItem(hospitalCode, language,
                request.getJubsuDate(), request.getDrgBunho());
        if (CollectionUtils.isEmpty(listObject)) {
            String result = drg2010Repository.getDrgsDRG5100P01SetBarDrgBunho(hospitalCode, request.getJubsuDate(), request.getDrgBunho());
            if (!StringUtils.isEmpty(result)) {
                response.setBarDrgBunho(result);
            }
        } else {
            for (DrgsDRG5100P01OrderJungboListItemInfo item : listObject) {
                DrgsModelProto.DrgsDRG5100P01OrderJungboInfo.Builder info = DrgsModelProto.DrgsDRG5100P01OrderJungboInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getSeq1())) {
                    info.setSeq1(item.getSeq1());
                }
                if (!StringUtils.isEmpty(item.getSeq2()) && !item.getSeq2().equals("SEQ_2")) {
                    info.setSeq2(item.getSeq2());
                }
                if (!StringUtils.isEmpty(item.getText1())) {
                    info.setText1(item.getText1());
                }
                if (!StringUtils.isEmpty(item.getText2()) && !item.getText2().equals("TEXT_2")) {
                    info.setText2(item.getText2());
                }
                if (!StringUtils.isEmpty(item.getText3()) && !item.getText2().equals("TEXT_3")) {
                    info.setText3(item.getText3());
                }
                if (!StringUtils.isEmpty(item.getRemark())) {
                    info.setRemark(item.getRemark());
                }
                if (!StringUtils.isEmpty(item.getBarDrgBunho())) {
                    info.setBarDrgBunho(item.getBarDrgBunho());
                }
                if (!StringUtils.isEmpty(item.getBunho())) {
                    info.setBunho(item.getBunho());
                }

                DrgsDRG5100P01JungboListInfo object = drg2010Repository.getDrgsDRG5100P01JungboListInfo(hospitalCode, item.getBunho(), item.getRemark());
                if (object != null) {
                    DrgsModelProto.DrgsDRG5100P01JungboInfo.Builder jungboInfo = DrgsModelProto.DrgsDRG5100P01JungboInfo.newBuilder();
                    if (!StringUtils.isEmpty(object.getHeight())) {
                        jungboInfo.setHeight(object.getHeight());
                    }
                    if (!StringUtils.isEmpty(object.getCm())) {
                        jungboInfo.setCm(object.getCm());
                    }
                    if (!StringUtils.isEmpty(object.getWeight())) {
                        jungboInfo.setWeight(object.getWeight());
                    }
                    if (!StringUtils.isEmpty(object.getKg())) {
                        jungboInfo.setKg(object.getKg());
                    }
                    if (!StringUtils.isEmpty(object.getCplResult())) {
                        jungboInfo.setCplResult(object.getCplResult());
                    }
                    if (!StringUtils.isEmpty(object.getComments())) {
                        jungboInfo.setComments(object.getComments());
                    }
                    if (!StringUtils.isEmpty(object.getCnt())) {
                        jungboInfo.setCnt(object.getCnt().toString());
                    }
                    info.setJungboInfo(jungboInfo);
                }
                response.addOrderJungboItem(info);
            }
        }
        return response.build();
    }
}
