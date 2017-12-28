package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

public class IFS0003U00SaveLayoutTest extends MessageRequestTest {

    @Test
    public void testIFS0003U00SaveLayoutHandlerTest() throws InterruptedException {

        BassModelProto.IFS0003U00GrdIFS0003Info.Builder item = BassModelProto.IFS0003U00GrdIFS0003Info.newBuilder();
        item.setMapGubun("IF_ORCA_GWA");
        item.setMapGubunYmd("2016/03/19");
        item.setOcsCode("99");
        item.setOcsCodeName("\345\206\205\347\247\221");
        item.setOcsDefaultYn("Y");
        item.setIfCode("99");
        item.setIfCodeName("\345\206\205\347\247\221");
        item.setIfDefaultYn("Y");
        item.setAcctType("00");
        item.setRowState("Added");

        List<BassModelProto.IFS0003U00GrdIFS0003Info> dts =
                new ArrayList<BassModelProto.IFS0003U00GrdIFS0003Info>();
        dts.add(item.build());
        
        BassServiceProto.IFS0003U00SaveLayoutRequest request = BassServiceProto.IFS0003U00SaveLayoutRequest
                .newBuilder()
                .setUserId("343ADM")
                .addAllInputList(dts).build();

        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));


    }
}
