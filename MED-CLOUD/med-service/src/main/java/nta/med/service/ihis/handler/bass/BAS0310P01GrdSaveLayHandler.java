package nta.med.service.ihis.handler.bass;

import nta.med.common.util.type.Triple;
import nta.med.common.util.type.Tuple;
import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.adm.*;
import nta.med.core.glossary.QueryType;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.BaseRepository;
import nta.med.data.dao.medi.adm.*;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.*;

/**
 * @author Tiepnm
 */
@Service
@Scope("prototype")
@Transactional
public class BAS0310P01GrdSaveLayHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdSaveLayRequest, SystemServiceProto.UpdateResponse> {
    @Resource
    private Adm9990Repository adm9990Repository;
    @Resource
    private Adm9991Repository adm9991Repository;
    @Resource
    private Adm9992Repository adm9992Repository;
    @Resource
    private Adm9995Repository adm9995Repository;
    @Resource
    private Adm9993Repository adm9993Repository;
    @Resource
    private Adm9996Repository adm9996Repository;
    @Resource
    private Adm9982Repository adm9982Repository;
    @Resource
    private Adm9997Repository adm9997Repository;
    @Resource
    private Adm9998Repository adm9998Repository;
    @Resource
    private Adm9983Repository adm9983Repository;
    @Resource
    private BaseRepository baseRepository;
    private static final Log LOGGER = LogFactory.getLog(BAS0310P01GrdSaveLayHandler.class);


    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, BassServiceProto.BAS0310P01GrdSaveLayRequest request) throws Exception {
        QueryType type = QueryType.get(request.getCurrentType());
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        List<AdmInterface> adm9990ListInsert = new ArrayList<AdmInterface>();
        List<String> adm9990ListRemove = new ArrayList<String>();
        List<AdmInterface> adm9991ListInsert = new ArrayList<AdmInterface>();
        List<String> adm9991ListRemove = new ArrayList<String>();
        List<AdmInterface> adm9992ListInsert = new ArrayList<AdmInterface>();
        List<String> adm9992ListRemove = new ArrayList<String>();
        List<AdmInterface> adm9993ListInsert = new ArrayList<AdmInterface>();
        List<String> adm9993ListRemove = new ArrayList<String>();
        List<AdmInterface> adm9995ListInsert = new ArrayList<AdmInterface>();
        List<String> adm9995ListRemove = new ArrayList<String>();
        List<AdmInterface> adm9996ListInsert = new ArrayList<AdmInterface>();
        List<String> adm9996ListRemove = new ArrayList<String>();
        List<AdmInterface> adm9982ListInsert = new ArrayList<AdmInterface>();
        List<String> adm9982ListRemove = new ArrayList<String>();
        List<AdmInterface> adm9997ListInsert = new ArrayList<AdmInterface>();
        List<String> adm9997ListRemove = new ArrayList<String>();
        List<AdmInterface> adm9998ListInsert = new ArrayList<AdmInterface>();
        List<String> adm9998ListRemove = new ArrayList<String>();
        List<AdmInterface> adm9983ListInsert = new ArrayList<AdmInterface>();
        List<String> adm9983ListRemove = new ArrayList<String>();
        String language = getLanguage(vertx, sessionId);
        AdmInterface admInterface;
        try {
            for (BassModelProto.BAS0310P01GrdJinryoMasterInfo bas0310P01GrdJinryoMasterInfo : request.getDtList()) {

                switch (type) {
                    case SANGCODE:
                        adm9990ListRemove.add(bas0310P01GrdJinryoMasterInfo.getA3());
                        admInterface = new Adm9990();
                        adm9990ListInsert.add(getAdmInterface(request, admInterface, bas0310P01GrdJinryoMasterInfo, language));
                        break;
                    case SUSIKCODE:
                        adm9991ListRemove.add(bas0310P01GrdJinryoMasterInfo.getA3());
                        admInterface = new Adm9991();
                        adm9991ListInsert.add(getAdmInterface(request, admInterface, bas0310P01GrdJinryoMasterInfo, language));
                        break;
                    case DRUGCODE:
                        adm9992ListRemove.add(bas0310P01GrdJinryoMasterInfo.getA3());
                        admInterface = new Adm9992();
                        adm9992ListInsert.add(getAdmInterface(request, admInterface, bas0310P01GrdJinryoMasterInfo, language));
                        break;
                    case JINRYOCODE:
                        adm9995ListRemove.add(bas0310P01GrdJinryoMasterInfo.getA3());
                        admInterface = new Adm9995();
                        adm9995ListInsert.add(getAdmInterface(request, admInterface, bas0310P01GrdJinryoMasterInfo, language));
                        break;
                    case TOKUTEICODE:
                        adm9993ListRemove.add(bas0310P01GrdJinryoMasterInfo.getA3());
                        admInterface = new Adm9993();
                        adm9993ListInsert.add(getAdmInterface(request, admInterface, bas0310P01GrdJinryoMasterInfo, language));
                        break;
                    case JOJECODE:
                        adm9996ListRemove.add(bas0310P01GrdJinryoMasterInfo.getA3());
                        admInterface = new Adm9996();
                        adm9996ListInsert.add(getAdmInterface(request, admInterface, bas0310P01GrdJinryoMasterInfo, language));
                        break;
                    case DRGSAKURA:
                        adm9982ListRemove.add(bas0310P01GrdJinryoMasterInfo.getA1());
                        admInterface = new Adm9982();
                        adm9982ListInsert.add(getAdmInterface(request, admInterface, bas0310P01GrdJinryoMasterInfo, language));
                        break;
                    case GENDRG:
                        adm9998ListRemove.add(bas0310P01GrdJinryoMasterInfo.getA6());
                        admInterface = new Adm9998();
                        adm9998ListInsert.add(getAdmInterface(request, admInterface, bas0310P01GrdJinryoMasterInfo,language));
                        break;
                    case GENDRMAP:

                        adm9997ListRemove.add(bas0310P01GrdJinryoMasterInfo.getA2());
                        admInterface = new Adm9997();
                        adm9997ListInsert.add(getAdmInterface(request, admInterface, bas0310P01GrdJinryoMasterInfo, language));
                        break;
                    case YJCODE:
                        adm9983ListRemove.add(bas0310P01GrdJinryoMasterInfo.getA1());
                        admInterface = new Adm9983();
                        adm9983ListInsert.add(getAdmInterface(request, admInterface, bas0310P01GrdJinryoMasterInfo, language));
                        break;

                }


            }
            Map<String, Tuple<String, Triple<AdmRepository, List<AdmInterface>, List<String>>>> map = new HashMap<>();
            map.put(QueryType.SANGCODE.getValue(), new Tuple<>("a3", new Triple<>(adm9990Repository, adm9990ListInsert, adm9990ListRemove)));
            map.put(QueryType.SUSIKCODE.getValue(), new Tuple<>("a3", new Triple<>(adm9991Repository, adm9991ListInsert, adm9991ListRemove)));
            map.put(QueryType.DRUGCODE.getValue(), new Tuple<>("a3", new Triple<>(adm9992Repository, adm9992ListInsert, adm9992ListRemove)));
            map.put(QueryType.JINRYOCODE.getValue(), new Tuple<>("a3", new Triple<>(adm9995Repository, adm9995ListInsert, adm9995ListRemove)));
            map.put(QueryType.TOKUTEICODE.getValue(), new Tuple<>("a3", new Triple<>(adm9993Repository, adm9993ListInsert, adm9993ListRemove)));
            map.put(QueryType.JOJECODE.getValue(), new Tuple<>("a3", new Triple<>(adm9996Repository, adm9996ListInsert, adm9996ListRemove)));
            map.put(QueryType.DRGSAKURA.getValue(), new Tuple<>("a1", new Triple<>(adm9982Repository, adm9982ListInsert, adm9982ListRemove)));
            map.put(QueryType.GENDRG.getValue(), new Tuple<>("a6", new Triple<>(adm9998Repository, adm9998ListInsert, adm9998ListRemove)));
            map.put(QueryType.GENDRMAP.getValue(), new Tuple<>("a2", new Triple<>(adm9997Repository, adm9997ListInsert, adm9997ListRemove)));
            map.put(QueryType.YJCODE.getValue(), new Tuple<>("a1", new Triple<>(adm9983Repository, adm9983ListInsert, adm9983ListRemove)));

            cleanAndSave(request.getCurrentType(), map);


        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            response.setResult(false);
            throw new ExecutionException(response.build());
        }


        response.setResult(true);
        return response.build();
    }

    public void cleanAndSave(String currentType, Map<String, Tuple<String, Triple<AdmRepository,
            List<AdmInterface>, List<String>>>> map) throws NoSuchFieldException, IllegalAccessException {
        Tuple<String, Triple<AdmRepository, List<AdmInterface>, List<String>>> tupe = map.get(currentType);
        tupe.getV2().getV1().deleteAdm(tupe.getV2().getV3());
        //tupe.getV2().getV1().deleteAdm();
        save(tupe.getV2().getV2(), tupe.getV1());
    }

    private AdmInterface getAdmInterface(BassServiceProto.BAS0310P01GrdSaveLayRequest request, AdmInterface admInterface, BassModelProto.BAS0310P01GrdJinryoMasterInfo bas0310P01GrdJinryoMasterInfo, String language) {
        admInterface.setSysDate(new Date());
        admInterface.setSysId(request.getUserId());
        BeanUtils.copyProperties(bas0310P01GrdJinryoMasterInfo, admInterface, language);
        return admInterface;
    }

    public void save(List<AdmInterface> admInterfaces, String uniqueCheck) throws NoSuchFieldException, IllegalAccessException {

        Map<String, AdmInterface> admMap = new HashMap<>();
        for (AdmInterface adm : admInterfaces) {
            if (uniqueCheck.equals("a3")) {
                if (!admMap.containsKey(adm.getA3())) {
                    admMap.put(adm.getA3(), adm);
                } else {
                    admMap.remove(adm.getA3());
                    admMap.put(adm.getA3(), adm);
                }
            } else if (uniqueCheck.equals("a1")) {
                if (!admMap.containsKey(adm.getA1())) {
                    admMap.put(adm.getA1(), adm);
                } else {
                    admMap.remove(adm.getA1());
                    admMap.put(adm.getA1(), adm);
                }
            } else if (uniqueCheck.equals("a2")) {
                if (!admMap.containsKey(adm.getA2())) {
                    admMap.put(adm.getA2(), adm);
                } else {
                    admMap.remove(adm.getA2());
                    admMap.put(adm.getA2(), adm);
                }
            } else if (uniqueCheck.equals("a6")) {
                if (!admMap.containsKey(adm.getA6())) {
                    admMap.put(adm.getA6(), adm);
                } else {
                    admMap.remove(adm.getA6());
                    admMap.put(adm.getA6(), adm);
                }
            }
        }

        List<AdmInterface> admInterfaceList = new ArrayList<>();
        for (Map.Entry<String, AdmInterface> entry : admMap.entrySet()) {
            admInterfaceList.add(entry.getValue());

        }
        baseRepository.saveObjects(admInterfaceList);

    }
}
